using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{

    [SerializeField] GameObject textField = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }
    public void ShowTooltip()
    {
        textField.SetActive(true);
        Debug.Log("ToolTip Show");
    }
    public void HideTooltip()
    {
        textField.SetActive(false);
        Debug.Log("ToolTip Hide");
    }

    public void ShowOrHideTooltip()
    {
        if (gameObject.activeSelf)
            HideTooltip();
        else
            ShowTooltip();
    }
}
