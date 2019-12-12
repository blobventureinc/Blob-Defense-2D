using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AttributeManager player;
    //[SerializeField] private GameObject gameMenu;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject startRoundButton;
    [SerializeField] private GameObject roundTimerPanel;
    [SerializeField] private Text roundText;

    [SerializeField] private Spawner spawner;

    [SerializeField] private int wave = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        //gameMenu.SetActive(false);
        gameOverUI.SetActive(false);
        startRoundButton.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(player.health.value <= 0) {
            Time.timeScale = 0.00001f;
            gameOverUI.SetActive(true);
        }
        if (wave == 0) {
            roundTimerPanel.SetActive(false);
        } else {
            roundTimerPanel.SetActive(true);
        }
    }

    public void NextWave() {
        spawner.SpawnNextWave();
        wave++;
        roundText.text = "Wave " + wave + " / 10";
    }

    public void OpenMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
