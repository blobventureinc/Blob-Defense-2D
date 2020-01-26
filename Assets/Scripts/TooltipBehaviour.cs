using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePos, 0.3f);
            if (colliders != null)
            {
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject.name == "Tooltip")
                        colliders[i].gameObject.GetComponent<Tooltip>().ShowOrHideTooltip();
                }
            }
        }
    }
}
