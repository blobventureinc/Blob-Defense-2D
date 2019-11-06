using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform prefabHealthBar;
    [SerializeField] private Transform barSpriteContainer = null;
    private HealthSystem healthSystem;

    public void UpdateHealthBar() {
        barSpriteContainer.localScale = new Vector3(healthSystem.HealthPercent, 1);
    }

    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.onHealthChange.AddListener(UpdateHealthBar);
        // HealthBar added to Prefab itself, no need to Instantiate
        // prefabHealthBar = Instantiate(Resources.Load("HealthBar", typeof(Transform)), new Vector3(0, 1), Quaternion.identity, gameObject.transform) as Transform;
        UpdateHealthBar();
    }
}
