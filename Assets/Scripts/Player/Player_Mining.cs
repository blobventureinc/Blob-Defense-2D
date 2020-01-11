using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mining : MonoBehaviour
{
    public bool isMining; //Toggled off by movement to cancel mining
    public int miningTimer; //Increments to time mining process
    private Resource resourceScript = null;
    [SerializeField] private Tile_Targeting targetingScript = null;
    [SerializeField] private Player_Movement movementScript = null;
    [SerializeField] private AttributeManager attributeScript = null;

    [SerializeField] private GameObject playerActionBar = null;
    [SerializeField] private Transform bar = null;

    void Start()
    {
        isMining = false;
        miningTimer = 0;
        resourceScript = null;
    }

    void Update()
    {
        if (movementScript.isMoving)
        {
            isMining = false;
        }
        //if(movementScript.mouseMovementDone) {
        //    Mine();
        //    movementScript.mouseMovementDone = false;
        //}
        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("Mining Start");
            Mine();
        }
    }

    public void Mine()
    {
        if (!isMining)
        {
            StartCoroutine(MiningCoroutine());
            Debug.Log("Start Mining Coroutine");
        }
    }

    IEnumerator MiningCoroutine()
    {
        Debug.Log("Inside Coroutine");
        Vector3 target = targetingScript.gettargetLoc();
        target.x += (float)0.5; target.y += (float)0.5;
        Vector2 point = new Vector2(target.x, target.y);
        Collider2D[] collider = Physics2D.OverlapCircleAll(point, (float)0.5); //look for colliders on target tile
        if (collider.Length >= 1)
        { //if collider located
            GameObject obj = collider[0].gameObject; //get their gameobject
            resourceScript = obj.GetComponent<Resource>(); //get their script
            Debug.Log("FOUND: " + resourceScript.type + ", VALUE: " + resourceScript.goldValue);
            isMining = true;
            while (obj != null && isMining)
            {
                if (miningTimer == resourceScript.duration)
                {
                    obj = null;
                }
                else
                {
                    yield return new WaitForSeconds(1);
                    miningTimer++;
                    if (playerActionBar != null)
                    {
                        playerActionBar.SetActive(true);
                    }
                    Debug.Log(((100 / resourceScript.duration) * miningTimer) * 0.01);
                    if (bar != null)
                    {
                        bar.localScale = new Vector3((float)(((100 / resourceScript.duration) * miningTimer) * 0.01), 1);
                    }
                    Debug.Log("INCREMENTING MINING TIMER");
                }
            }
            Debug.Log("MINING DONE/CANCELED");
            if (playerActionBar != null)
            {
                playerActionBar.SetActive(false);
            }
            if (isMining && attributeScript != null)
            {
                attributeScript.gold.Increase(resourceScript.goldValue);
                attributeScript.energy.Decrease(resourceScript.energyDrainValue);
                resourceScript.Destroy();
            }
            isMining = false;
            miningTimer = 0;
        }
    }
}
