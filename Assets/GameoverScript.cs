using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverScript : MonoBehaviour
{
    public void RestartLevel() {
        SceneManager.LoadScene("FromPrefabs");
    }
    public void GoToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
