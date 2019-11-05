using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(HealthBar))]
public class HealthSystem : MonoBehaviour
{
    public UnityEvent onHealthChange;
    public UnityEvent onDeath;

    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

    private HealthBar healthBar;

    // Start is called before the first frame update
    void Start() {
        onHealthChange.AddListener(UpdateHealthBar);
        healthBar = GetComponent<HealthBar>();
        healthBar.UpdateHealthBar(GetHealthPercent());
    }

    public int GetHealth() {
        return health;
    }

    public float GetHealthPercent() {
        return (float)health / maxHealth;
    }

    public void UpdateHealthBar() {
        healthBar.UpdateHealthBar(GetHealthPercent());
    }

    public void DestroyItself () {
        Destroy(gameObject.transform);
    }

    public void ApplyDamage (int dmg) {
        health -= dmg;
        onHealthChange.Invoke();
        if (health < 0) {
            health = 0;
            onDeath.Invoke();
        }
    }

    public void ApplyHeal (int heal) {
        health += heal;
        onHealthChange.Invoke();
        if (health > maxHealth) {
            health = maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug Stuff
        if (Input.GetKeyDown(KeyCode.F)) {
            ApplyDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            ApplyHeal(10);
        }
    }
}
