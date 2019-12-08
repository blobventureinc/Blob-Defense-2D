using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDamage : MonoBehaviour
{
    private GameObject enemyObject;
    private HealthSystem healthSystem;

    [SerializeField] private Damage damage;

    // Start is called before the first frame update
    void Start()
    {
        enemyObject = GameObject.Find("Enemy");
        healthSystem = enemyObject.GetComponent<HealthSystem>();
        //Debug.Log("Click 'd' to do Damage");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) {
            healthSystem.ApplyDamage(damage);
            Debug.Log("Do Damage");
        }
    }
}
