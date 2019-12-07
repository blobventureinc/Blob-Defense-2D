using UnityEngine;
using System.Collections;
 
public class BuildingManager : MonoBehaviour {

    [SerializeField] private GameObject[] buildings;
    private BuildingPlacement buildingPlacement;
    
 
    // Use this for initialization
    void Start () {
 
        buildingPlacement = GetComponent<BuildingPlacement>();
 
    }
 
    // Update is called once per frame
    void Update () {
 
    }

    //void OnGUI() {


    //    for (int i = 0; i < buildings.Length; i++) {
    //        if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 15 + Screen.height / 12 * i, 100, 30), buildings[i].name)) {
    //            buildingPlacement.SetItem(buildings[i]);
    //        }
    //    }
    //}

    public void Build() {
        //for (int i = 0; i < buildings.Length; i++) {
        //    if (GUI.Button(new Rect(Screen.width / 20, Screen.height / 15 + Screen.height / 12 * i, 100, 30), buildings[i].name)) {
        //        buildingPlacement.SetItem(buildings[i]);
        //    }
        //}
        buildingPlacement = GetComponent<BuildingPlacement>();
        buildingPlacement.SetItem(buildings[0]);
    }
}