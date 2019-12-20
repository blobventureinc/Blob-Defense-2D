using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTowerActionMenu : MonoBehaviour
{
    public TowerActionMenu towerActionMenu;
    public Tower tower;
    public AttributeManager attributeManager;

    private bool state;

    void Update() 
    {
        if(Input.GetButtonDown("Jump")) 
        {
            state = !state;
            if(state) 
            {
                if(tower != null) 
                {
                    towerActionMenu.ShowTowerActionMenu(attributeManager, tower);
                }
            } 
            else 
            {
                towerActionMenu.HideTowerActionMenu();
            }
        }
    }
}
