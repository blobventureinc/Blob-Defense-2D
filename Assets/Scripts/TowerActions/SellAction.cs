using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower Actions/Sell Action", fileName="NewSellAction", order = 0)]
public class SellAction : TowerAction
{
    public override bool DoAction(AttributeManager attributeManager, Tower tower)
    {
        tower.SellTower();
        return true;
    }
}
