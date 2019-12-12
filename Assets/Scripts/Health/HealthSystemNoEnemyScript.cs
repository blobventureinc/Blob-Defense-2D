using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystemNoEnemyScript : HealthSystem
{
    private AttributeManager player;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Castle") {
            Destroy(gameObject);
            player.health.Decrease(1);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<AttributeManager>();
        onDeath.AddListener(DestroyItself);
    }

    void DestroyItself()
    {
        Destroy(gameObject);
    }
}
