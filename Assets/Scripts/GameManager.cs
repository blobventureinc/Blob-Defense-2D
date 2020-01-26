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
    [SerializeField] private Canvas textTooltip;
    [SerializeField] private Text tooltipText;

    [Header("Path Spawner")]
    [SerializeField] private Spawner[] spawners = null;
    private int remaining_waves;
    private int wave = 0;

    public int goldPerRound;

    private bool isInCombat;

    bool wasIncreased = true;

    // Start is called before the first frame update
    void Start()
    {
        textTooltip.gameObject.SetActive(true);
        tooltipText.text = "\n Willkommen im Spiel!\n \n" +
            "Abbauen/Benutzen : Leertaste \n " +
            "Bewegung : WASD \n";
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
            wasIncreased = false;
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
            if (!wasIncreased) {
                player.gold.Increase(goldPerRound);
                wasIncreased = true;
                int rndEvent = Random.Range(1, 5);
                if (rndEvent == 1) {
                    player.energy.Increase(100);
                    tooltipText.text =
                    "Du hast die Nacht überlebt. \n" +
                    "Deine Beute hat dir 50 Gold eingebracht. \n" +
                    "Du hast den Rest der Nacht ruhig in deinen Gemächern verbracht. \n" +
                    "100% Energie wurden wiederhergestellt.";
                } else if (rndEvent == 2) {
                    player.energy.Increase(75);
                    tooltipText.text =
                    "Du hast die Nacht überlebt. \n" +
                    "Deine Beute hat dir 50 Gold eingebracht. \n" +
                    "Du hast den Rest der Nacht in deinen Gemächern verbracht. \n" +
                    "Schlechte Träume haben dich heimgesucht. \n" +
                    "75% Energie wurden wiederhergestellt.";
                } else if (rndEvent ==  3) {
                    player.energy.Increase(50);
                    tooltipText.text =
                    "Du hast die Nacht überlebt. \n" +
                    "Deine Beute hat dir 50 Gold eingebracht. \n" +
                    "Du hast den Rest der Nacht in einer Taverne verbracht. \n" +
                    "50% Energie wurden wiederhergestellt.";
                } else if (rndEvent == 4) {
                    player.energy.Increase(25);
                    tooltipText.text =
                    "Du hast die Nacht überlebt. \n" +
                    "Deine Beute hat dir 50 Gold eingebracht. \n" +
                    "Du hast den Rest der Nacht sturzbetrunken in einer Scheune verbracht. \n" +
                    "25% Energie wurden wiederhergestellt.";
                } else if (rndEvent == 5) {
                    tooltipText.text =
                    "Du hast die Nacht überlebt. \n" +
                    "Deine Beute hat dir 50 Gold eingebracht. \n" +
                    "Auf dem Weg nach Hause bist du überfallen worden. \n" +
                    "Man hat dich KO geschlagen. Du wachst auf der Straße wieder auf. \n" +
                    "0% Energie wurden wiederhergestellt.";
                }
                textTooltip.gameObject.SetActive(true);
            }
        }
    }

    public void NextWave()
    {
        player.gameObject.GetComponent<PlayerActioneer>().enabled = false;
        foreach (Spawner sp in spawners) {
            remaining_waves += sp.waves[wave].enemyWaves.Length;
        }
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
        player.gameObject.GetComponent<PlayerActioneer>().enabled = true;
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
