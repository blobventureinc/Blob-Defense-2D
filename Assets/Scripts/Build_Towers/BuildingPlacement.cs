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

    [SerializeField] private IngameConsole ingameConsoleUIElement;

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
            // Second Left-Click Mouse Button Down After Clicking on Button
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
                ingameConsoleUIElement.Add("Decreasing Gold by " + currentBuilding.GetComponentInChildren<Tower>().towerCost);
                att.gold.Decrease(currentBuilding.GetComponentInChildren<Tower>().towerCost);
                wasDecreased = true;
                ingameConsoleUIElement.Add("Tower has Placed");
            }
        } else if (hasPlaced) {
            hasPlaced = false;
            currentBuilding = null;
            ingameConsoleUIElement.Add("Tower Placement aborted!");
        }
    }
 
    public void SetItem(GameObject b){ 
        hasPlaced = false;
        currentBuilding = ((GameObject) Instantiate (b)).transform;
    }
}