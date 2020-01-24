using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class HighlightLightRange : MonoBehaviour
{
    private void OnMouseDown() {
        if (GetComponent<SpriteRenderer>().enabled == false) {
            GetComponent<SpriteRenderer>().enabled = true;
        } else {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
