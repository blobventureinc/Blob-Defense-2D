using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform prefabHealthBar;
    [SerializeField] private Transform barSpriteContainer = null;
    private HealthSystem healthSystem;

    public void UpdateHealthBar() {
        barSpriteContainer.localScale = new Vector3(healthSystem.healthPercent, 1);
    }

    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.onHealthChange.AddListener(UpdateHealthBar);
        UpdateHealthBar();
    }
}
