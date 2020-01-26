using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowGeneralTooltip : MonoBehaviour
{
    [SerializeField] GameObject tooltip;

    void OnMouseOver() {
        //If your mouse hovers over the GameObject with the script attached, output this message
        tooltip.SetActive(true);
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit() {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        tooltip.SetActive(false);
        Debug.Log("Mouse is no longer on GameObject.");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
