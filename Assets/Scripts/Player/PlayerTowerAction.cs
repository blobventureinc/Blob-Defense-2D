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

    private Transform selectedTowerTransform;

    void Start()
    {
        targetingScript = GetComponent<Tile_Targeting>();
        attributeScript = GetComponent<AttributeManager>();
    }

    void Update()
    {
        if (selectedTowerTransform != null)
        {
            if (Vector3.Distance(transform.position, selectedTowerTransform.position) > reachDistance)
            {
                towerActionMenu.HideTowerActionMenu();
            }
        }
    }

    public void Actioning(GameObject gameObject)
    {
        Tower tower = gameObject.GetComponentInChildren<Tower>();
        towerActionMenu.HideTowerActionMenu();
        towerActionMenu.ShowTowerActionMenu(attributeScript, tower);
        selectedTowerTransform = gameObject.transform;
    }
}
