using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographicSize = 4.0f;
        gameObject.transform.localPosition = new Vector3(0, 0.4f, -100f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            if (Camera.main.orthographicSize < 7.0f) {
                Debug.Log(gameObject.transform.position.y);
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 0.05f, -100f);
                Debug.Log(gameObject.transform.position.y);
                Camera.main.orthographicSize += 0.2f;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            if (Camera.main.orthographicSize > 4.0f) {
                gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, -100f);
                Camera.main.orthographicSize -= 0.2f;
            }
        }
    }
}
