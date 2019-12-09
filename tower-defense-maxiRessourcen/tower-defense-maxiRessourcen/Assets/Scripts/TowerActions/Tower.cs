using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public IEnumerator<TowerAction> TowerActions 
    {
        get 
        {
            foreach(TowerActionProvider provider in GetComponents<TowerActionProvider>()) 
            {
                foreach(TowerAction towerAction in provider.TowerActions) 
                {
                    yield return towerAction;
                }
            }
        }
    }

    public void DoAction(TowerAction towerAction) 
    {
        towerAction.DoAction(this);
    }

    public void SellTower() 
    {
        Destroy(gameObject);
    }

    public void UpgradeTower(GameObject towerUpgrade) 
    {
        Instantiate(towerUpgrade, Vector3.zero, Quaternion.identity, transform.parent);
        Destroy(gameObject);
    }
}
