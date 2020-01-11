using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttributeManager))]
public class ManaSystem : MonoBehaviour
{
    [SerializeField] private AttributeManager attributeManager = null;

    [Header("Resistances")]
    [SerializeField] private float _manaburnRes = 0.1f;

    public void ApplyDamage(int dmg)
    {
        attributeManager.mana.Decrease((int)(dmg * (1.0f - _manaburnRes)));
    }

    public void ApplyHeal(int heal)
    {
        attributeManager.mana.Increase(heal);
    }
}
