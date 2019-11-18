using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthBar))]
public class HealthSystem : MonoBehaviour {

    public UnityEvent onHealthChange;
    public UnityEvent onDeath;

    [Header("Health as (int) Total")]
    [SerializeField] private int _health = 100;
    [SerializeField] private int _maxHealth = 100;
    private float _healthPercent;

    [Header("DmgRes as Percent")]
    [SerializeField] private float _physicalRes = 0;
    [SerializeField] private float _poisonRes = 0;
    [SerializeField] private float _fireRes = 0;
    [SerializeField] private float _waterRes = 0;
    [SerializeField] private float _windRes = 0;
    [SerializeField] private float _earthRes = 0;
    [SerializeField] private float _shadowRes = 0;
    [SerializeField] private float _lightRes = 0;

    public int health {
        get {
            return _health;
        }
    }

    public int maxHealth {
        get {
            return _maxHealth;
        }
    }

    public float healthPercent {
        get {
            return (float)health / maxHealth;
        }
    }

    public bool isDead => _health <= 0;

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
        _health -= CalculateDamage(dmg);
        if (isDead) {
            _health = 0;
            onDeath.Invoke();
        }
        onHealthChange.Invoke();
    }

    public void ApplyHeal (int heal) {
        _health += heal;
        if (_health >= _maxHealth) {
            _health = _maxHealth;
        }
        onHealthChange.Invoke();
    }

}
