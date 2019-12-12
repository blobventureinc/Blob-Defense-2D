using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int towerCost;

    public TowerAction[] towerActions;

    /*public IEnumerator<TowerAction> TowerActions 
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
        Destroy(transform.parent.gameObject);
    }

    public void UpgradeTower(GameObject towerUpgrade, int price) 
    {
        var newTower = Instantiate(towerUpgrade, transform.parent.position, transform.parent.rotation, transform.parent.parent);
        newTower.GetComponentInChildren<Tower>().towerCost = towerCost + price;
        Destroy(transform.parent.gameObject);
    }
}
