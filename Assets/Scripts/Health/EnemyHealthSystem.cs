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

    [SerializeField] bool isHiddenEnemy = true;
    [SerializeField] SpriteRenderer spriteRenderer;

    bool resetted;
    bool hasLight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<AttributeManager>();
        onDeath.AddListener(DestroyItself);
    }

    private void FixedUpdate() {
        if (isHiddenEnemy) {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, 0.3f);
            if (GetLightColliderCount(colliders) != 0) {
                if (resetted == false) {
                    gameObject.SetActive(false);
                    gameObject.SetActive(true);
                    resetted = true;
                }
                gameObject.tag = "Enemy";
                return;
            } else {
                resetted = false;
            }
            gameObject.tag = "Untagged";
        }
    }

    private int GetLightColliderCount(Collider2D[] colliders) {
        int count = 0;
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject.tag == "Light") {
                count++;
            }
        }
        return count;
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
        GetComponent<ShadowCaster2D>().enabled = false;
        gameObject.tag = "Untagged";
        anim.SetBool("DeathTrigger", true);
        pathScript.speed = 0.0f;
        //Debug.Log("DestroyItself Called");
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
