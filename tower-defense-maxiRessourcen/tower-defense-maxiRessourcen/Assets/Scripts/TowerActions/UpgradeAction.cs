using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAction : TowerAction
{
    private GameObject towerUpgradePrefab;

    public UpgradeAction(string name, GameObject towerUpgradePrefab) : base(name) {
        this.towerUpgradePrefab = towerUpgradePrefab;
    }

    public override void DoAction(Tower tower)
    {
        tower.UpgradeTower(towerUpgradePrefab);
    }
}
