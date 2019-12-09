using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AttributeManager))]
public class HealthSystem : MonoBehaviour {

    [SerializeField] private AttributeManager attributeManager;

    public UnityEvent onDeath;

    [Header("DmgRes as Percent e.g. 0.1f for 10%")]
    [SerializeField] private float _physicalRes = 0;
    [SerializeField] private float _poisonRes = 0;
    [SerializeField] private float _fireRes = 0;
    [SerializeField] private float _waterRes = 0;
    [SerializeField] private float _windRes = 0;
    [SerializeField] private float _earthRes = 0;
    [SerializeField] private float _shadowRes = 0;
    [SerializeField] private float _lightRes = 0;

    public bool isDead => attributeManager.health.value <= 0;

    private int CalculateDamage(Damage dmg) {
        int calcDmg = 0;
        calcDmg += (int)(dmg._physicalDmg * (1 - _physicalRes));
        calcDmg += (int)(dmg._poisonDmg * (1 - _poisonRes));
        calcDmg += (int)(dmg._fireDmg * (1 - _fireRes));
        calcDmg += (int)(dmg._waterDmg * (1 - _waterRes));
        calcDmg += (int)(dmg._windDmg * (1 - _windRes));
        calcDmg += (int)(dmg._earthDmg * (1 - _earthRes));
        calcDmg += (int)(dmg._shadowDmg * (1 - _shadowRes));
        calcDmg += (int)(dmg._lightDmg * (1 - _lightRes));
        return calcDmg;
    }

    public void ApplyDamage (Damage dmg) {
        attributeManager.health.Decrease(CalculateDamage(dmg));
        if (isDead) {
            onDeath.Invoke();
        }
    }

    public void ApplyHeal (int heal) {
        attributeManager.health.Increase(heal);
    }
}
