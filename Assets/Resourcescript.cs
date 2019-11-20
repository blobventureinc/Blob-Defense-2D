using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {
    public string type;
    public Vector2Int loc;

    public Resource(string type, Vector2Int loc) {
        this.type = type;
        this.loc = loc;
    }
}

public class Resourcescript : MonoBehaviour {
    public List<Resource> resources;


    // Start is called before the first frame update
    void Start()
    {
        this.AddResource("wood", new Vector2Int(1,2));
    }

    // Update is called once per frame
    void Update() {

    }
    public Resource FindResourceAt(Vector2Int pos) {
        Debug.Log("SEARCHING AT:" + pos.x + " , " + pos.y);
        Resource r = null;
        for (int i = 0; i < resources.Count; i++) {
            r = resources[i];
            if ( r.loc == new Vector2Int(pos.x, pos.y) ) return r;
        }         
        return null;
    }
    public void AddResource(string type, Vector2Int loc) {
        Resource r = new Resource(type, loc);
        resources.Add(r);
    }
}
