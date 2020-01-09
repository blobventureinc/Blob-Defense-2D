using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tile_Targeting), typeof(AttributeManager))]
public class PlayerBuildAction : MonoBehaviour
{
    public GameObject[] towers;
    public GameObject buildActionMenu;
    public float reachDistance;
    bool active = false;

    private Vector3 selectedPosition;

    void Start()
    {
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, selectedPosition) > reachDistance)
        {
            hideUI();
        }
    }

    public void Actioning(Vector3 targetLoc)
    {
        if (active) { hideUI(); } else { showUI(); }
        selectedPosition = targetLoc;
        //buildActionMenu.transform.position = transform.position;
    }

    public void hideUI()
    {
        buildActionMenu.SetActive(false); active = false;
    }

    public void showUI()
    {
        buildActionMenu.SetActive(true); active = true;
    }


    public void buildTower(int i)
    {
        GameObject t = Instantiate(towers[i], selectedPosition, Quaternion.identity) as GameObject;
        Debug.Log(selectedPosition);
        hideUI();
    }
}
