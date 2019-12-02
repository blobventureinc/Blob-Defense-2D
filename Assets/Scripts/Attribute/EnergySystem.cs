using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AttributeManager))]
public class EnergySystem : MonoBehaviour {
    [SerializeField] private AttributeManager attributeManager;

    [Header("Resistances")]
    [SerializeField] private float _energyburnRes = 0.1f;

    public void ApplyDamage(int dmg) {
        attributeManager.energy.Decrease((int)(dmg * (1.0f - _energyburnRes)));
    }

    public void ApplyHeal(int heal) {
        attributeManager.energy.Increase(heal);
    }
}
