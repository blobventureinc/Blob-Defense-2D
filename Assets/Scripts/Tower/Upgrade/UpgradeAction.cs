using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Tower Actions/Upgrade Action", fileName="NewUpgradeAction", order = 0)]
public class UpgradeAction : PricyTowerAction
{
    public GameObject towerUpgradePrefab;

    protected override void DoActionImpl(Tower tower)
    {
        tower.UpgradeTower(towerUpgradePrefab, gold);
    }
}
