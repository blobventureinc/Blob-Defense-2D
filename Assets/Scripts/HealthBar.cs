using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform prefabHealthBar;
    private Transform healthBar;

    public void UpdateHealthBar(float percent) {
        healthBar.localScale = new Vector3(percent, 1);
    }
    // Start is called before the first frame update
    void Start()
    {
        HealthSystem healthSystem = GetComponent<HealthSystem>();
        prefabHealthBar = Instantiate(Resources.Load("HealthBar", typeof(Transform)), new Vector3(0, 1), Quaternion.identity, gameObject.transform) as Transform;
        healthBar = prefabHealthBar.Find("Bar");
        healthSystem.UpdateHealthBar();
    }
}
