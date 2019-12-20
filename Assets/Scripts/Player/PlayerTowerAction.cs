using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tile_Targeting), typeof(AttributeManager))]
public class PlayerTowerAction : MonoBehaviour
{
    public TowerActionMenu towerActionMenu;
    public float reachDistance;

    private Tile_Targeting targetingScript = null;
    private AttributeManager attributeScript = null;
    private Player_Movement movementScript = null;

    private Transform selectedTowerTransform;

    void Start()
    {
        targetingScript = GetComponent<Tile_Targeting>();
        attributeScript = GetComponent<AttributeManager>();
        movementScript = GetComponent<Player_Movement>();
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
                    selectedTowerTransform = collider.transform;
                    break;
                }
            }
        }
        if(Vector3.Distance(transform.position, selectedTowerTransform.position) > reachDistance) 
        {
            towerActionMenu.HideTowerActionMenu();
        }
    }
}
