using UnityEngine;
using System.Collections;
using UnityEngine.Tilemaps;
 
[RequireComponent(typeof(BuildingPlacement))]
public class BuildingManager : MonoBehaviour {

    [SerializeField] private IngameConsole ingameConsoleUIElement;
    [SerializeField] private GameObject[] buildings = new GameObject[2];
    private Tower[] towers;
    private BuildingPlacement buildingPlacement;
    [SerializeField] private TilemapRenderer tilemapRenderer;

    public void Start() {
        // Get all TowerScripts from Tower GameObjects
        towers = new Tower[buildings.Length];
        for (int i=0; i<buildings.Length; i++) {
            towers[i] = buildings[i].GetComponentInChildren<Tower>();
        }
    }

    public void Build(int tower) {
        tilemapRenderer.enabled = true;
        buildingPlacement = GetComponent<BuildingPlacement>();
        Debug.Log(towers[0]);
        if (gameObject.GetComponent<AttributeManager>().gold.value >= towers[tower].towerCost) {
            ingameConsoleUIElement.Add("Trying to Build Tower: " + towers[tower].transform.parent.name);
            buildingPlacement.SetItem(buildings[tower]);
        } else {
            ingameConsoleUIElement.Add("Not Enough Gold To Build Tower");
        }
    }
}