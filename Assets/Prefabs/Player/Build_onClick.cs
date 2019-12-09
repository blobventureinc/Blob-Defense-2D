using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class Build_onClick : MonoBehaviour {

    [SerializeField] private GameObject Tower;
    [SerializeField] private Tilemap currentMap;
    Dictionary<Vector3Int, GameObject> objects = new Dictionary<Vector3Int, GameObject>();
    [SerializeField] private Tile TowerPos;

    private bool IsMouseOverUI() {
        return EventSystem.current.IsPointerOverGameObject();
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0) && !IsMouseOverUI()) {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = currentMap.WorldToCell(new Vector3Int( Mathf.RoundToInt(mouseWorldPos.x), Mathf.RoundToInt(mouseWorldPos.y),0));
            Tile t = currentMap.GetTile(coordinate) as Tile;
            TryInstantiateGameObjectAtPosition(coordinate);
        }
    }

    void TryInstantiateGameObjectAtPosition(Vector3Int coordinate) {
        if (!ObjectOnPosition(coordinate)) {            
            Instantiate(Tower, coordinate, Quaternion.identity);
            currentMap.SetTile(coordinate, TowerPos);
            currentMap.RefreshTile(coordinate);
            objects.Add(coordinate, Tower);
        }
    }

    bool ObjectOnPosition(Vector3Int pos) {
        if (objects.ContainsKey(pos)) {
            return true;
        }
        else {
            return false;
        }
    }
}