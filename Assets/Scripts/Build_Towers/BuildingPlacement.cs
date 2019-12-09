using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class BuildingPlacement : MonoBehaviour {
 
    private Transform currentBuilding;
    [SerializeField] private Tilemap currentMap;
    [SerializeField] private Tile TowerPos;
    [SerializeField] private Camera camera;
    private bool hasPlaced;
    Dictionary<Vector3Int, bool> objects = new Dictionary<Vector3Int, bool>();
    [SerializeField] private Player_Movement playerMovement;
    [SerializeField] private BuildingManager buildingManager;
    [SerializeField] private AttributeManager att;
    [SerializeField] private Tile_Targeting targetingScript;

    private bool wasDecreased;

    // Use this for initialization
    void Start () {
        Cursor.visible = true;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.tag == "Tower") {
            if (currentBuilding != null) {
                currentBuilding.GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
        }
    }

    // Update is called once per frame
    public void Update () {
        if (currentBuilding != null && !hasPlaced) {
            wasDecreased = false;
            currentBuilding.GetComponentInChildren<SpriteRenderer>().enabled = true;
            currentBuilding.position = (new Vector3(0, 0, 0));
            Vector3 m = Input.mousePosition;
            m = new Vector3(m.x, m.y, 0);
            if (Input.GetMouseButtonDown(0)) {
                currentBuilding.GetComponentInChildren<SpriteRenderer>().enabled = false;
                Vector3 clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 target = targetingScript.gettargetLoc();
                target.x += (float)0.5; target.y += (float)0.5;
                Vector2 point = new Vector2(target.x, target.y);
                Collider2D collider = Physics2D.OverlapCircle(clickPos, (float)0.5);
                Debug.Log(collider.gameObject.name);
                if (!(collider.gameObject.name == "Script")) {
                    Destroy(currentBuilding.gameObject);
                }
                playerMovement.clickPos.z = 0;
                playerMovement.MoveTo(clickPos);
            }
            Vector3 p = camera.ScreenToWorldPoint(m);
            currentBuilding.position = new Vector3Int(Mathf.RoundToInt(p.x), Mathf.RoundToInt(p.y), 0);
            if (Input.GetMouseButtonDown(0) && currentBuilding.gameObject != null) {
                Debug.Log(currentBuilding.position);
                Vector3Int coordinate = currentMap.WorldToCell(new Vector3Int(Mathf.RoundToInt(p.x), Mathf.RoundToInt(p.y), 0));
                Debug.Log(currentMap.GetTile(coordinate));
                if (currentMap.GetTile(coordinate) != null) {
                    Destroy(currentBuilding.gameObject);
                } else {
                    hasPlaced = true;
                    //currentMap.SetTile(coordinate, TowerPos);
                    //currentMap.RefreshTile(coordinate);
                }
            }
            //playerMovement.clickedTile = TowerPos;
        }
        if (currentBuilding != null) {
            if (hasPlaced && currentBuilding.GetComponentInChildren<SpriteRenderer>().enabled && !wasDecreased) {
                att.gold.Decrease(buildingManager.cannonTowerGold);
                wasDecreased = true;
            }
        }
    }
 
    public void SetItem(GameObject b){ 
        hasPlaced = false;
        currentBuilding = ((GameObject) Instantiate (b)).transform;
    }

    public bool IsMouseOverUI() {
        return EventSystem.current.IsPointerOverGameObject();
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