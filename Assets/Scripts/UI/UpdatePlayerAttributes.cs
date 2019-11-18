using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerAttributes : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private Slider livesBar = null;
    [SerializeField] private Text livesText = null;

    [SerializeField] private Slider manaBar = null;
    [SerializeField] private Text manaText = null;

    [SerializeField] private Slider energyBar = null;
    [SerializeField] private Text energyText = null;

    [SerializeField] private Slider expBar = null;
    [SerializeField] private Text levelText = null;
    [SerializeField] private Text expText = null;

    [SerializeField] private Text goldText = null;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

        livesBar.maxValue = player.lives.valueMax;
        manaBar.maxValue = player.mana.valueMax;
        energyBar.maxValue = player.energy.valueMax;
        expBar.maxValue = player.exp.valueMax;

        player.onLivesChange.AddListener(UpdateLivesBar);
        player.onManaChange.AddListener(UpdateManaBar);
        player.onEnergyChange.AddListener(UpdateEnergyBar);
        player.onExpChange.AddListener(UpdateExpBar);
        player.onLevelChange.AddListener(UpdateLevel);
        player.onGoldChange.AddListener(UpdateGold);

        player.onStart.AddListener(UpdateLivesBar);
        player.onStart.AddListener(UpdateManaBar);
        player.onStart.AddListener(UpdateEnergyBar);
        player.onStart.AddListener(UpdateExpBar);
        player.onStart.AddListener(UpdateLevel);
        player.onStart.AddListener(UpdateGold);
    }

    public void UpdateLivesBar() {
        livesBar.maxValue = player.lives.valueMax;
        livesBar.value = player.lives.value;
        livesText.text = "HP: " + player.lives.value.ToString()+" / "+ player.lives.valueMax.ToString();
    }
    public void UpdateManaBar() {
        manaBar.maxValue = player.mana.valueMax;
        manaBar.value = player.mana.value;
        manaText.text = "MP: " + player.mana.value.ToString() + " / " + player.mana.valueMax.ToString();
    }
    public void UpdateEnergyBar() {
        energyBar.maxValue = player.energy.valueMax;
        energyBar.value = player.energy.value;
        energyText.text = "EN: "+player.energy.value.ToString() + "%";
    }
    public void UpdateExpBar() {
        expBar.maxValue = player.exp.valueMax;
        expBar.value = player.exp.value;
        expText.text = "Exp: " + player.exp.value.ToString() + " / " + player.exp.valueMax.ToString();
    }
    public void UpdateLevel() {
        levelText.text = "Level: " + player.level.value.ToString() + " / " + player.level.valueMax.ToString();
    }

    public void UpdateGold() {
        goldText.text = player.gold.value.ToString();
    }
}
