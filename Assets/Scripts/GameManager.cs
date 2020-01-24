using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private AttributeManager player = null;
    //[SerializeField] private GameObject gameMenu;
    [SerializeField] private Animator dayNightCycle = null;

    [Header("UI Elements")]
    [SerializeField] private GameObject gameOverUI = null;
    [SerializeField] private GameObject startRoundButton = null;
    [SerializeField] private GameObject roundTimerPanel = null;
    [SerializeField] private Text roundText = null;

    [Header("Path Spawner")]
    [SerializeField] private Spawner[] spawners = null;
    private int remaining_waves;
    private int wave = 0;

    private bool isInCombat;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        //gameMenu.SetActive(false);
        gameOverUI.SetActive(false);
        startRoundButton.SetActive(true);
        foreach (Spawner sp in spawners)
            sp.waveEnded.AddListener(RoundEnd);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInCombat)
        {
            roundTimerPanel.SetActive(true);
            startRoundButton.SetActive(false);
            if (player.health.value <= 0)
            {
                Time.timeScale = 0.00001f;
                gameOverUI.SetActive(true);
            }
        }
        else
        {
            roundTimerPanel.SetActive(false);
            startRoundButton.SetActive(true);
        }
    }

    public void NextWave()
    {
        remaining_waves = spawners.Length;
        isInCombat = true;
        foreach (Spawner sp in spawners)
            sp.SpawnNextWave();
        wave++;
        roundText.text = "Wave " + wave + " / " + spawners[0].waves.Length;
        dayNightCycle.SetBool("isDay", false);
    }

    public void RoundEnd()
    {
        remaining_waves--;
        if (remaining_waves == 0)
        {
            isInCombat = false;
            player.level.Increase(1);
            dayNightCycle.SetBool("isDay", true);
        }
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
