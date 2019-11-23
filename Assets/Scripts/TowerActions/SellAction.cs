using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellAction : TowerAction
{
    public SellAction(string name): base(name) {}

    public override void DoAction(Tower tower)
    {
        tower.SellTower();
    }
}
