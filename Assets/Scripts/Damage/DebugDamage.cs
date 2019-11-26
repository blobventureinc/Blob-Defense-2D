using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDamage : MonoBehaviour
{
    private GameObject enemyObject;
    private DamageSystem damageSystem;

    [SerializeField] private Damage damage;

    // Start is called before the first frame update
    void Start()
    {
        enemyObject = GameObject.Find("Enemy");
        damageSystem = enemyObject.GetComponent<DamageSystem>();
        Debug.Log("Click 'd' to do Damage");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) {
            damageSystem.ApplyDamage(damage);
            Debug.Log("Do Damage");
        }
    }
}
