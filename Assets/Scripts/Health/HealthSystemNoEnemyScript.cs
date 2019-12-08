using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystemNoEnemyScript : HealthSystem
{
    // Start is called before the first frame update
    void Start()
    {
        onDeath.AddListener(DestroyItself);
    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}
