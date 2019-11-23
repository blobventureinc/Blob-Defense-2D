using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tower))]
public class DebugTowerActionExecutor : MonoBehaviour
{
    private Tower tower;

    void Start() 
    {
        tower = GetComponent<Tower>();
    }

    void Update() 
    {
        if(Input.GetButtonDown("Jump")) 
        {
            IEnumerator<TowerAction> towerActions = tower.TowerActions;
            if(towerActions.MoveNext()) {
                tower.DoAction(towerActions.Current);
            }
        }
    }
}
