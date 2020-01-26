using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{

    [SerializeField] GameObject tooltip = null;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void FixedUpdate() { }
    public void ShowTooltip()
    {
        tooltip.SetActive(true);
    }
    public void HideTooltip()
    {
        tooltip.SetActive(false);
    }

    public void ShowOrHideTooltip()
    {
        if (tooltip.activeSelf)
            HideTooltip();
        else
            ShowTooltip();
    }
}
