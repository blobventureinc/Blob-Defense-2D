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

    Vector3 oldPosition;
    Vector3 newPosition;
    Vector3 direction;
    bool step;

    bool resetted;
    bool hasLight;
    bool destroyed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<AttributeManager>();
        onDeath.AddListener(DestroyItself);
        step = true;
        destroyed = false;
    }

    private void Update() {
        if (step) {
            oldPosition = transform.position;
            step = false;
        } else {
            newPosition = transform.position;
            var heading = newPosition - oldPosition;
            var distance = heading.magnitude;
            Vector3 direction = heading / distance;
            if (!float.IsNaN(direction.x)) {
                anim.SetFloat("SpeedX", direction.x);
                anim.SetFloat("SpeedY", direction.y);
            }
            step = true;
        }
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
                isHiddenEnemy = true;
                gameObject.tag = "Untagged";
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
