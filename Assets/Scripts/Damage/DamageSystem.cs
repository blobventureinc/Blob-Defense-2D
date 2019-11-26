using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AttributeManager))]
public class DamageSystem : MonoBehaviour {

    [SerializeField] private AttributeManager attributeManager;

    public UnityEvent onDeath;

    [Header("DmgRes as Percent")]
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
        calcDmg += (int)(dmg._physicalDmg * (_physicalRes / 100) );
        calcDmg += (int)(dmg._poisonDmg * (_poisonRes / 100) );
        calcDmg += (int)(dmg._fireDmg * (_fireRes / 100) );
        calcDmg += (int)(dmg._waterDmg * (_waterRes / 100) );
        calcDmg += (int)(dmg._windDmg * (_windRes / 100) );
        calcDmg += (int)(dmg._earthDmg * (_earthRes / 100) );
        calcDmg += (int)(dmg._shadowDmg * (_shadowRes / 100) );
        calcDmg += (int)(dmg._lightDmg * (_lightRes / 100) );
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
