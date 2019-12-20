using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerAction: ScriptableObject
{
    public string name;

    public abstract bool DoAction(AttributeManager attributeManager, Tower tower);
}
