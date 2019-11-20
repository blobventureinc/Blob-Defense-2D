using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : Object {
    public string type;
    public Vector2Int loc;
    public SpriteRenderer sprite;

    public Resource(string type, Vector2Int loc) {
        this.type = type;
        this.loc = loc;
        this.sprite = new SpriteRenderer();
       
    }
}

public class Resourcescript : MonoBehaviour {
    public List<Resource> resources;


    // Start is called before the first frame update
    void Start()
    {
        resources = new List<Resource>();
        this.AddResource("stone", new Vector2Int(1, 2));
        this.AddResource("stone", new Vector2Int(0, 2));
        this.AddResource("stone", new Vector2Int(1, 1));
        this.AddResource("stone", new Vector2Int(0, 1));
        this.AddResource("stone", new Vector2Int(0, 0));
        Debug.Log("RESOURCE ADDED");
        
    }

    // Update is called once per frame
    void Update() {

    }
    public Resource FindResourceAt(Vector2Int pos) {
        Debug.Log("SEARCHING AT:" + pos.x + " , " + pos.y);
        //Resource r = null;
        foreach (Resource r in resources) {
            if (r.loc == pos) {
                Debug.Log("RETURNING RESOURCE");
                return r;
            }
        }         
        return null;
    }
    public void AddResource(string type, Vector2Int loc) {
        Resource r = new Resource(type, loc);
        resources.Add(r);
    }
}
