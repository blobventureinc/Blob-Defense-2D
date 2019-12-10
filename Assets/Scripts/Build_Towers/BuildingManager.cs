using UnityEngine;
using System.Collections;
 
[RequireComponent(typeof(BuildingPlacement))]
public class BuildingManager : MonoBehaviour {

    [SerializeField] private IngameConsole ingameConsoleUIElement;
    [SerializeField] private GameObject[] buildings = new GameObject[2];
    private Tower[] towers;
    private BuildingPlacement buildingPlacement;

    public void Start() {
        // Get all TowerScripts from Tower GameObjects
        towers = new Tower[buildings.Length];
        for (int i=0; i<buildings.Length; i++) {
            towers[i] = buildings[i].GetComponentInChildren<Tower>();
        }
    }

    public void Build(int tower) {
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