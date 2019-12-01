using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int towerCost;

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
    }*/

    public void DoAction(AttributeManager attributeManager, TowerAction towerAction) 
    {
        towerAction.DoAction(attributeManager, this);
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
