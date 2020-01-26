using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameSpeed : MonoBehaviour
{
    public void Set(float value) {
        Time.timeScale = value;
    }
}
