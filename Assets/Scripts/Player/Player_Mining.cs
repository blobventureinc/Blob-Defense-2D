using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mining : MonoBehaviour
{

    public bool isMining;
    public int miningTimer;
    Vector2 input;
    Stone resourceScript;
    [SerializeField] private Tile_Targeting targetingScript = null;
    // Start is called before the first frame update
    void Start() {
        isMining = false;
        miningTimer = 0;
        input = new Vector2(0, 0);
        resourceScript = null;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return) && !isMining) {
            StartCoroutine(Mine());
        }
    }

    IEnumerator Mine() {
        Vector3Int target = targetingScript.gettargetLoc();
        Debug.Log("SEARCHING AT:" + target.x + " , " + target.y);
        Collider[] objarr = Physics.OverlapSphere(target, 1);
        if (objarr.Length == 1) {
            GameObject ob = objarr[0].gameObject;
            resourceScript = ob.GetComponent<Stone>();
            Debug.Log("FOUND: " + resourceScript.type + ", VALUE: " + resourceScript.value);
            isMining = true;
            while (ob != null && isMining) {
                if(miningTimer == resourceScript.duration) {
                    resourceScript.Mine();
                    ob = null;
                } else {
                    yield return new WaitForSeconds(1);
                    input.x = Input.GetAxisRaw("Horizontal");
                    input.y = Input.GetAxisRaw("Vertical");
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
