using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public string type;
    int value;
    // Start is called before the first frame update
    void Start()
    {
        type = "stone";
        value = 3;
        Debug.Log("STONE INITIALIZED");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Mine() {
        Object.Destroy(gameObject, value);
        return value;
    }

    private void OnDestroy()
    {
        
    }
}
