using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string type;
    public int value;
    public int duration;
    // Start is called before the first frame update
    void Start()
    {
        type = "stone";
        value = 3;
        duration = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Mine() {
        Object.Destroy(gameObject);
        return value;
    }

    private void OnDestroy()
    {
        
    }
}
