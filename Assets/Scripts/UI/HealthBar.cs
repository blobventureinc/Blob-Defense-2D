using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform prefabHealthBar;
    [SerializeField] private Transform barSpriteContainer = null;
    private AttributeManager attributeManager;

    public void UpdateHealthBar() {
        barSpriteContainer.localScale = new Vector3(attributeManager.health.GetValuePercent(), 1);
        //Debug.Log("Inside UpdateHealthBar() " + attributeManager.health.GetValuePercent());
    }

    public void Init()
    {
        attributeManager = GetComponent<AttributeManager>();
        attributeManager.health.onValueChange.AddListener(UpdateHealthBar);
        UpdateHealthBar();
    }
}
