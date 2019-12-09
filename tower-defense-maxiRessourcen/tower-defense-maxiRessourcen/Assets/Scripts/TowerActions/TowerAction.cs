using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerAction
{
    public string name;

    public TowerAction(string name) {
        this.name = name;
    }

    public abstract void DoAction(Tower tower);
}
