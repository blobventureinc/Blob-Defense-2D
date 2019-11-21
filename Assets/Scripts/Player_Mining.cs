using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Mining : MonoBehaviour
{
    public bool isMining;
    [SerializeField] private Tile_Targeting targetingScript = null;
    // Start is called before the first frame update
    void Start()
    {
        isMining = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Vector3Int target = targetingScript.gettargetLoc();
            Debug.Log("SEARCHING AT:" + target.x + " , " + target.y);
            Collider[] objarr = Physics.OverlapSphere(target, 1);
            if (objarr.Length == 1)
            {
                GameObject ob = objarr[0].gameObject;
                Debug.Log("FOUND: " + ob.GetComponent<Stone>().type + ", MINED: " + ob.GetComponent<Stone>().Mine());

            }
        }
    }
}
