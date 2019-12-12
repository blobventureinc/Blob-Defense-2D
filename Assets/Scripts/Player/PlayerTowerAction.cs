using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tile_Targeting), typeof(AttributeManager))]
public class PlayerTowerAction : MonoBehaviour
{
    public TowerActionMenu towerActionMenu;

    private Tile_Targeting targetingScript = null;
    private AttributeManager attributeScript = null;

    void Start()
    {
        targetingScript = GetComponent<Tile_Targeting>();
        attributeScript = GetComponent<AttributeManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) 
        {
            Vector3 target = targetingScript.gettargetLoc();
            target.x += (float)0.5; target.y += (float)0.5;
            Vector2 point = new Vector2(target.x, target.y);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(point, (float)0.5);

            foreach(var collider in colliders) 
            {
                Tower tower = collider.GetComponent<Tower>();
                if(tower != null) {
                    towerActionMenu.HideTowerActionMenu();
                    towerActionMenu.ShowTowerActionMenu(attributeScript, tower);
                    break;
                }
            }
        }
    }
}
