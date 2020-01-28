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
    [SerializeField] private GameObject tileHighlightingLight = null;

    [Header("UI Elements")]
    [SerializeField] private GameObject winGameUI = null;
    [SerializeField] private GameObject gameOverUI = null;
    [SerializeField] private GameObject startRoundButton = null;
    [SerializeField] private GameObject roundTimerPanel = null;
    [SerializeField] private Text roundText = null;
    [SerializeField] private Canvas textTooltip = null;
    [SerializeField] private Text textTooltipText = null;
    [SerializeField] private GameObject tutorialTooltip = null;
    [SerializeField] private Text tutorialToolTipText = null;
    [SerializeField] private Text enemyCheckerText = null;

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
        //textTooltip.gameObject.SetActive(true);
        //textTooltipText.text = "\n Willkommen im Spiel!\n \n" +
        //    "Abbauen/Benutzen : Leertaste \n " +
        //    "Bewegung : WASD \n";
        tutorialTooltip.gameObject.SetActive(true);
        //tutorialToolTipText.text = "\n Willkommen im Spiel! \n\n" +
        //    "Wenn du neu im Spiel bist, solltest du das Tutorial aufmerksam lesen. \n" +
        //    "Wir wünschen dir viel Spass im Spiel!";
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
            if (player.level.value == 16) {
                Time.timeScale = 0.00001f;
                winGameUI.SetActive(true);
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
                    textTooltipText.text =
                    "Du hast die Nacht überlebt. \n" +
                    "Deine Beute hat dir 50 Gold eingebracht. \n" +
                    "Du hast den Rest der Nacht ruhig in deinen Gemächern verbracht. \n" +
                    "100% Energie wurden wiederhergestellt.";
                } else if (rndEvent == 2) {
                    player.energy.Increase(75);
                    textTooltipText.text =
                    "Du hast die Nacht überlebt. \n" +
                    "Deine Beute hat dir 50 Gold eingebracht. \n" +
                    "Du hast den Rest der Nacht in deinen Gemächern verbracht. \n" +
                    "Schlechte Träume haben dich heimgesucht. \n" +
                    "75% Energie wurden wiederhergestellt.";
                } else if (rndEvent ==  3) {
                    player.energy.Increase(50);
                    textTooltipText.text =
                    "Du hast die Nacht überlebt. \n" +
                    "Deine Beute hat dir 50 Gold eingebracht. \n" +
                    "Du hast den Rest der Nacht in einer Taverne verbracht. \n" +
                    "50% Energie wurden wiederhergestellt.";
                } else if (rndEvent == 4) {
                    player.energy.Increase(25);
                    textTooltipText.text =
                    "Du hast die Nacht überlebt. \n" +
                    "Deine Beute hat dir 50 Gold eingebracht. \n" +
                    "Du hast den Rest der Nacht sturzbetrunken in einer Scheune verbracht. \n" +
                    "25% Energie wurden wiederhergestellt.";
                } else if (rndEvent == 5) {
                    textTooltipText.text =
                    "Du hast die Nacht überlebt. \n" +
                    "Deine Beute hat dir 50 Gold eingebracht. \n" +
                    "Auf dem Weg nach Hause bist du überfallen worden. \n" +
                    "Man hat dich KO geschlagen. Du wachst auf der Straße wieder auf. \n" +
                    "0% Energie wurden wiederhergestellt.";
                }
                textTooltip.gameObject.SetActive(true);
            }
        }
        if (player.level.value == 0) {
            enemyCheckerText.text = "Name: Grüner Blob \n" +
                "Lebenspunkte: 100 \n" +
                "Anzahl: 5 \n" +
                "Geschwindigkeit: Langsam \n" +
                "Resistenzen: 10% Physisch \n\n" +
                "Verwilderter Blob aus dem Wald. Hat lange" +
                "kein Tageslicht mehr erblickt.";

        }
        if (player.level.value == 1) {
            enemyCheckerText.text = "Name: Grüner Blob \n" +
                "Lebenspunkte: 100 \n" +
                "Anzahl: 10 \n" +
                "Geschwindigkeit: Langsam \n" +
                "Resistenzen: 10% Physisch \n\n" +
                "Verwilderter Blob aus dem Wald. Hat lange" +
                "kein Tageslicht mehr erblickt.";

        }
        if (player.level.value == 2) {
            enemyCheckerText.text = "Name: Kleine Fledermaus \n" +
                "Lebenspunkte: 150 \n" +
                "Anzahl: 10 \n" +
                "Geschwindigkeit: Langsam \n" +
                "Resistenzen: - \n\n" +
                "Die Augen funkeln bedrohlich!";

        }
        if (player.level.value == 3) {
            enemyCheckerText.text = "Name: Kleine Schabe \n" +
                "Lebenspunkte: 100 \n" +
                "Anzahl: 24 \n" +
                "Geschwindigkeit: Normal \n" +
                "Resistenzen: 50% Gift \n\n" +
                "\"Dance Dance Dance!\"";

        }
        if (player.level.value == 4) {
            enemyCheckerText.text = "Name: Roter Blob \n" +
                "Lebenspunkte: 100 \n" +
                "Anzahl: 20 \n" +
                "Geschwindigkeit: Normal \n" +
                "Resistenzen: 40% Physisch \n\n" +
                "Natürlische Schleim Rüstung.";

        }
        if (player.level.value == 5) {
            enemyCheckerText.text = "Name: Roter Blob \n" +
                "Lebenspunkte: 100 \n" +
                "Anzahl: 20 \n" +
                "Geschwindigkeit: Normal \n" +
                "Resistenzen: 40% Physisch \n\n" +
                "Natürlische Schleim Rüstung.";

        }
        if (player.level.value == 6) {
            enemyCheckerText.text = "Name: Roter Blob \n" +
                "Lebenspunkte: 100 \n" +
                "Anzahl: 20 \n" +
                "Geschwindigkeit: Normal \n" +
                "Resistenzen: 40% Physisch \n\n" +
                "Natürlische Schleim Rüstung.";

        }
        if (player.level.value == 7) {
            enemyCheckerText.text = "Name: Roter Blob \n" +
                "Lebenspunkte: 100 \n" +
                "Anzahl: 20 \n" +
                "Geschwindigkeit: Normal \n" +
                "Resistenzen: 40% Physisch \n\n" +
                "Natürlische Schleim Rüstung.";

        }
        if (player.level.value == 8) {
            enemyCheckerText.text = "Name: Roter Blob \n" +
                "Lebenspunkte: 100 \n" +
                "Anzahl: 20 \n" +
                "Geschwindigkeit: Normal \n" +
                "Resistenzen: 40% Physisch \n\n" +
                "Natürlische Schleim Rüstung.";

        }
    }

    public void NextWave()
    {
        //Disable the actioneer and tileHighlighting on waveStart. You can not build in combat phase
        player.gameObject.GetComponent<PlayerActioneer>().enabled = false;
        tileHighlightingLight.SetActive(false);

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
            //Reenable the actioneer and highlighting
            player.gameObject.GetComponent<PlayerActioneer>().enabled = true;
            tileHighlightingLight.SetActive(true);

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
