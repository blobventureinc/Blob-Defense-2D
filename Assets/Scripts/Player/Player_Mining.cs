using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mining : MonoBehaviour
{
    public bool isMining; //Toggled off by movement to cancel mining
    public int miningTimer; //Increments to time mining process
    Resource resourceScript;
    [SerializeField] private Tile_Targeting targetingScript = null;

    void Start() {
        isMining = false;
        miningTimer = 0;
        resourceScript = null;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return) && !isMining) {
            StartCoroutine(MiningCoroutine());
        }
    }

    public void Mine() {
        if(!isMining) {
            StartCoroutine(MiningCoroutine());
        }      
    }

    IEnumerator MiningCoroutine() {
        Vector3Int target = targetingScript.gettargetLoc();
        Collider[] collider = Physics.OverlapSphere(target, 1); //look for colliders on target tile
        if (collider.Length == 1) { //if collider located
            GameObject obj = collider[0].gameObject; //get their gameobject
            resourceScript = obj.GetComponent<Resource>(); //get their script
            Debug.Log("FOUND: " + resourceScript.type + ", VALUE: " + resourceScript.value);
            isMining = true;
            while (obj != null && isMining) {
                if(miningTimer == resourceScript.duration) {
                    resourceScript.Mine();
                    obj = null;
                } else {
                    yield return new WaitForSeconds(1);
                    miningTimer++;
                    Debug.Log("INCREMENTING MINING TIMER");
                }    
            }
            Debug.Log("MINING DONE/CANCELED");
            isMining = false;
            miningTimer = 0;
        }   
    }
}
