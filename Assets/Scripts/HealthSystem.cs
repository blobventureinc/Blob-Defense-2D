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
        set {
            _health = value;
            if (_health <= 0) {
                _health = 0;
                onDeath.Invoke();
            }
            if (_health >= _maxHealth) {
                _health = _maxHealth;
            }
            onHealthChange.Invoke();
        }
    }

    public int maxHealth {
        get {
            return _maxHealth;
        }
        set {
            _maxHealth = value;
        }
    }
    public float healthPercent {
        get {
            return (float) health / maxHealth; 
        }
    }

    public void ApplyDamage (int dmg) {
        health -= dmg;
    }

    public void ApplyHeal (int heal) {
        health += heal;
    }

    void Start() {
        healthBar = GetComponent<HealthBar>();
    }

    void Update()
    {
        // Debug Stuff
        if (Input.GetKeyDown(KeyCode.F)) {
            ApplyDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            ApplyHeal(10);
        }
        //Debug.Log("HP%:"+healthPercent);
    }
}
