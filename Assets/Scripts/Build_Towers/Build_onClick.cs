using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Build_onClick : MonoBehaviour {

    public GameObject Tower;    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        var a = new List<KeyValuePair<Vector3, int>>();
        GridLayout gridLayout = transform.parent.GetComponentInParent<GridLayout>();
        Vector3Int cellPosition = gridLayout.WorldToCell(transform.position);
        transform.position = gridLayout.CellToWorld(cellPosition);
        Debug.Log(cellPosition);
        Vector3 towerPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Instantiate(Tower,towerPos, Quaternion.identity);
        a.Add(new KeyValuePair<Vector3, int>(towerPos, 1));
        

    }
}
