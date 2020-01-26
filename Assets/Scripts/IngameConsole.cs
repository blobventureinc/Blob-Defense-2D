using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IngameConsole : MonoBehaviour {

    public void Add(string line) {
        GetComponent<Text>().text = System.DateTime.Now +": "+ line + "\n" + GetComponent<Text>().text;
    }
}