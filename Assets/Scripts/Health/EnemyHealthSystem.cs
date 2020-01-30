using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.Rendering.Universal;

public class EnemyHealthSystem : HealthSystem
{
    private AttributeManager player;
    [SerializeField] WalkAlongPath pathScript = null;
    private IEnumerator animCoroutine;

    [SerializeField] GameObject healthBar = null;
    [SerializeField] Animator anim = null;

    bool isHiddenEnemy = true;
    [SerializeField] SpriteRenderer spriteRenderer;

    bool resetted;
    bool hasLight;
    bool destroyed;

    int overlapping;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<AttributeManager>();
        onDeath.AddListener(DestroyItself);
        destroyed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("Triggered by: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Light") {
            if (isHiddenEnemy && !destroyed) {
                //Debug.Log("Inside isHiddenEnemy If");
                //Debug.Log(gameObject.tag);
                gameObject.SetActive(false);
                gameObject.SetActive(true);
                isHiddenEnemy = false;
                if (gameObject.tag == "Enemy") {
                    overlapping++;
                }
                gameObject.tag = "Enemy";
            }
        }
        if (collision.gameObject.tag == "Castle")
        {
            killSelf(1);
            player.health.Decrease(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Light") {
            if (!isHiddenEnemy) {
                if (overlapping == 0) {
                    isHiddenEnemy = true;
                    gameObject.tag = "Untagged";
                } else {
                    overlapping--;
                }
            }
        }
    }

    void DestroyItself()
    {
        destroyed = true;
        healthBar.SetActive(false);
        if (GetComponent<ShadowCaster2D>() != null) {
            GetComponent<ShadowCaster2D>().enabled = false;
        }
        gameObject.tag = "Untagged";
        anim.SetBool("DeathTrigger", true);
        pathScript.speed = 0.0f;
        Debug.Log("DestroyItself Called");
        animCoroutine = WaitAndPrint(0.7f);
        StartCoroutine(animCoroutine);
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            //print("WaitAndPrint " + Time.time);
            Destroy(gameObject);
            StopCoroutine(animCoroutine);
        }
    }
}
