using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAction : TowerAction
{
    private GameObject towerUpgradePrefab;

    public UpgradeAction(string name, GameObject towerUpgradePrefab) : base(name) {
        this.towerUpgradePrefab = towerUpgradePrefab;
    }

    //TODO: Implement Method
    public override void DoAction()
    {
        throw new System.NotImplementedException();
    }
}
