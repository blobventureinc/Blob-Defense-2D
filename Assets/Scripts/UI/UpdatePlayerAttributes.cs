using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerAttributes : MonoBehaviour
{
    [SerializeField] private AttributeManager player;

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

    public void Init()
    {
        player.health.onValueChange.AddListener(UpdateLivesBar);
        player.mana.onValueChange.AddListener(UpdateManaBar);
        player.energy.onValueChange.AddListener(UpdateEnergyBar);
        player.exp.onValueChange.AddListener(UpdateExpBar);
        player.level.onValueChange.AddListener(UpdateLevel);
        player.gold.onValueChange.AddListener(UpdateGold);

        UpdateLivesBar();
        UpdateManaBar();
        UpdateEnergyBar();
        UpdateExpBar();
        UpdateLevel();
    }

    public void UpdateLivesBar() {
        livesBar.maxValue = player.health.valueMax;
        livesBar.value = player.health.value;
        livesText.text = "HP: " + player.health.value.ToString()+" / "+ player.health.valueMax.ToString();
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
