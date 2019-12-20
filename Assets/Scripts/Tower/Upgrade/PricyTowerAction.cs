using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PricyTowerAction : TowerAction
{
    public int gold;

    public bool IsDoable(AttributeManager attributeManager) 
    {
        return attributeManager.gold.value >= gold;
    }

    public override bool DoAction(AttributeManager attributeManager, Tower tower) 
    {
        if(IsDoable(attributeManager)) 
        {
            attributeManager.gold.Decrease(gold);
            DoActionImpl(tower);
            return true;
        }
        else
        {
            return false;
        }
    }

    protected abstract void DoActionImpl(Tower tower);
}
