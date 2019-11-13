using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthBar))]
public class HealthSystem : MonoBehaviour
{
    private HealthBar healthBar;

    public UnityEvent onHealthChange;
    public UnityEvent onDeath;

    [SerializeField] private int _health = 100;
    [SerializeField] private int _maxHealth = 100;
    private float _healthPercent;

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
            return (float) health / maxHealth; 
        }
    }

    public bool isDead => _health <= 0;

    public void ApplyDamage (int dmg) {
        _health -= dmg;
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

    void Start() {
        healthBar = GetComponent<HealthBar>();
    }
}
