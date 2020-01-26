using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverTooltip : MonoBehaviour
{
    public Tooltip tooltip;
    public Text text;
    public string tooltipText = "";

    private void Start() {
        GameObject temp = GameObject.Find("GeneralToolTip");
        tooltip = temp.GetComponent<Tooltip>();
    }


    void OnMouseEnter() {
        tooltip.ShowOrHideTooltip();
        text = tooltip.GetComponentInChildren<Text>();
        text.text = tooltipText.Replace("\\n", "\n");
    }


void OnMouseExit() {
        tooltip.ShowOrHideTooltip();
    }
}
