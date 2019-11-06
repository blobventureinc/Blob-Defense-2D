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

    [SerializeField] private int health = 100;
    [SerializeField] private int maxHealth = 100;
    private float healthPercent;

    public int Health {
        get {
            return health;
        }
    }
    public int MaxHealth {
        get {
            return maxHealth;
        }
    }
    public float HealthPercent {
        get {
            return (float) health / maxHealth; 
        }
    }

    public void ApplyDamage (int dmg) {
        health -= dmg;
        if (health <= 0) {
            health = 0;
            onDeath.Invoke();
        }
        onHealthChange.Invoke();
    }

    public void ApplyHeal (int heal) {
        health += heal;
        if (health >= maxHealth) {
            health = maxHealth;
        }
        onHealthChange.Invoke();
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
        Debug.Log("HP%:"+HealthPercent);
    }
}
