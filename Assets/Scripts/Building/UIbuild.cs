using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbuild : MonoBehaviour {
    //[SerializeField] Transform Tower;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    public void Update() {

    }

    public void BuildAction() {
        Vector3 m = Input.mousePosition;
        //m = new Vector3(m.x, m.y, transform.position.y);
        Vector3 p = Camera.main.ScreenToWorldPoint(m);
        //Tower.position = new Vector3(p.x, p.y, 0);
        if (Input.GetMouseButtonDown(0)) {
            m = Input.mousePosition;
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(m.x, m.y, 0));
            pos.z = 0;
            Debug.Log(pos);
            //BuildAction(p);
            PrefabBuild pb = new PrefabBuild();
            //pb.BuildTower(pos);
        }
    }
}
