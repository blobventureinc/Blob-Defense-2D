using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerAction: ScriptableObject
{
    public string actionName;
    public int cost;

    public abstract bool DoAction(AttributeManager attributeManager, Tower tower);
}
