using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mining : MonoBehaviour
{
    public bool isMining; //Toggled off by movement to cancel mining
    public int miningTimer; //Increments to time mining process
    private Resource resourceScript = null;
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
    }

    public void Mine(GameObject obj)
    {
        if (!isMining)
        {
            StartCoroutine(MiningCoroutine(obj));
        }
    }

    IEnumerator MiningCoroutine(GameObject obj)
    {
        resourceScript = obj.GetComponent<Resource>(); //get their script
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
                if (bar != null)
                {
                    bar.localScale = new Vector3((float)(((100 / resourceScript.duration) * miningTimer) * 0.01), 1);
                }
            }
        }
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
