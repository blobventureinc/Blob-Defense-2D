using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class BuildingPlacement : MonoBehaviour {
 
    private Transform currentBuilding;
    [SerializeField] private Tilemap currentMap;
    [SerializeField] private Tile TowerPos;
    [SerializeField] private Camera camera;
    private bool hasPlaced;
    Dictionary<Vector3Int, bool> objects = new Dictionary<Vector3Int, bool>();
    [SerializeField] private Player_Movement playerMovement;

    [SerializeField] private AttributeManager att;
    [SerializeField] private int cannonTowerGold;

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
            Vector3 p = camera.ScreenToWorldPoint(m);
            currentBuilding.position = new Vector3Int(Mathf.RoundToInt(p.x), Mathf.RoundToInt(p.y), 0);   
            if (Input.GetMouseButtonDown(0)){
                Debug.Log(currentBuilding.position);
                hasPlaced = true;
                Vector3Int coordinate = currentMap.WorldToCell(new Vector3Int(Mathf.RoundToInt(p.x), Mathf.RoundToInt(p.y), 0));
                   Debug.Log(currentMap.GetTile(coordinate));
                if (att.gold.value >= cannonTowerGold) {
                    if (currentMap.GetTile(coordinate) != null) {
                        Destroy(currentBuilding.gameObject);
                    } else {
                        att.gold.Decrease(cannonTowerGold);
                        currentMap.SetTile(coordinate, TowerPos);
                        currentMap.RefreshTile(coordinate);
                    }
                }
                //playerMovement.clickedTile = TowerPos;
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