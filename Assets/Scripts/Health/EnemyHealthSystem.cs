using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealthSystem: HealthSystem
{
    private AttributeManager player;
    [SerializeField] WalkAlongPath pathScript;
    private IEnumerator animCoroutine;

    [SerializeField] GameObject healthBar;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<AttributeManager>();
        onDeath.AddListener(DestroyItself);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Castle")
        {
            killSelf();
            player.health.Decrease(1);
        }
    }

    void DestroyItself()
    {
        healthBar.SetActive(false);
        gameObject.tag = "Untagged";
        anim.SetBool("DeathTrigger", true);
        pathScript.speed = 0.0f;
        //Debug.Log("DestroyItself Called");
        animCoroutine = WaitAndPrint(0.7f);
        StartCoroutine(animCoroutine);
    }

    private IEnumerator WaitAndPrint(float waitTime) {
        while (true) {
            yield return new WaitForSeconds(waitTime);
            //print("WaitAndPrint " + Time.time);
            Destroy(gameObject);
            StopCoroutine(animCoroutine);
        }
    }
}
