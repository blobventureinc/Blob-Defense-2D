using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class BuildingPlacement : MonoBehaviour {
 
    private Transform currentBuilding;
    [SerializeField] private Tilemap currentMap;
    [SerializeField] private Tile TowerPos;
    private bool hasPlaced;
    Dictionary<Vector3Int, bool> objects = new Dictionary<Vector3Int, bool>();

    // Use this for initialization
    void Start () {
        Cursor.visible = true;
    }
 
    // Update is called once per frame
    public void Update () {
        if (currentBuilding != null && !hasPlaced  ) {
            currentBuilding.position = (new Vector3( 0, 0, 0));
            Vector3 m = Input.mousePosition;
            m = new Vector3(m.x,m.y,0);
            Debug.Log(m);
            //Vector3 p = GetComponent<Camera>().ScreenToWorldPoint(m);
            Vector3 p = Camera.main.WorldToScreenPoint(m);
            Debug.Log(p);
            currentBuilding.position = new Vector3Int(Mathf.RoundToInt(p.x), Mathf.RoundToInt(p.y), 0);
            
            if (Input.GetMouseButtonDown(0)){
                Debug.Log(currentBuilding.position);
                hasPlaced = true;
                Vector3Int coordinate = currentMap.WorldToCell(new Vector3Int(Mathf.RoundToInt(p.x), Mathf.RoundToInt(p.y), 0));
                TryInstantiateGameObjectAtPosition(coordinate);
            }
        }
    }
 
    public void SetItem(GameObject b){ 
        hasPlaced = false;
        currentBuilding = ((GameObject) Instantiate (b)).transform;
    }

    //check weather there is an object on this position
    void TryInstantiateGameObjectAtPosition(Vector3Int coordinate) {
        if (!ObjectOnPosition(coordinate)) {
            currentMap.SetTile(coordinate, TowerPos);
            currentMap.RefreshTile(coordinate);
            objects.Add(coordinate,  hasPlaced);
        }
        else {
            //remove gameobject frome scene... somehow           
        }
    }
    //check the dictionary for key/value pair of Vector3Int and bool
    bool ObjectOnPosition(Vector3Int pos) {
        if (objects.ContainsKey(pos)) {
            return true;
        }
        else {
            return false;
        }
    }
}