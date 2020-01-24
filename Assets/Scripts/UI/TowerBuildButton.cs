using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuildButton : MonoBehaviour
{

    [SerializeField] private int index;
    [SerializeField] private PlayerBuildAction playerBuildAction;
    [SerializeField] private Button button;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (playerBuildAction.canBuildTower(index))
        {
            button.interactable = true;
        }
        else
        {
            button.interactable = false;
        }
    }
}
