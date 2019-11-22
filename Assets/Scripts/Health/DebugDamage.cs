using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDamage : MonoBehaviour
{
    private GameObject enemyObject;
    private HealthSystem enemyHealth;

    [Header("Damage Types")] 
    [SerializeField] private int physicalDmg = 0;
    [SerializeField] private int poisonDmg = 0;
    [SerializeField] private int fireDmg = 0;
    [SerializeField] private int waterDmg = 0;
    [SerializeField] private int windDmg = 0;
    [SerializeField] private int earthDmg = 0;
    [SerializeField] private int shadowDmg = 0;
    [SerializeField] private int lightDmg = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemyObject = GameObject.Find("Enemy");
        enemyHealth = enemyObject.GetComponent<HealthSystem>();
        Debug.Log("Click 'd' to do Damage");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) {
            enemyHealth.ApplyDamage(new Damage(physicalDmg, poisonDmg, fireDmg, waterDmg, windDmg, earthDmg, shadowDmg, lightDmg));
        }
    }
}
