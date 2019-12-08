using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerActionProvider : MonoBehaviour
{
    private TowerAction[] _towerActions;

    public TowerAction[] TowerActions => _towerActions;

    protected abstract TowerAction[] CreateTowerActions();

    void Start() {
        _towerActions = CreateTowerActions();
    }
}
