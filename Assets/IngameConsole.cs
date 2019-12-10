using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IngameConsole : MonoBehaviour {

    public void Add(string line) {
        GetComponent<Text>().text = line + "\n" + GetComponent<Text>().text;
    }
}