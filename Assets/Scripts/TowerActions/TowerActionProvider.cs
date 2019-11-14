using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerActionProvider : MonoBehaviour, ISerializationCallbackReceiver
{
    private TowerAction[] _towerActions;

    public TowerAction[] TowerActions => _towerActions;

    protected abstract TowerAction[] CreateTowerActions();

    public void OnAfterDeserialize()
    {
        _towerActions = CreateTowerActions();
    }

    public void OnBeforeSerialize() {}
}
