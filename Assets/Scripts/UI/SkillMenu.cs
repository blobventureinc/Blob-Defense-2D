using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SkillMenu : MonoBehaviour
{
    public GameObject skillButtonPrefab = null;
    private List<GameObject> buttons = null;

    // TODO: This Method has to be wired up to an Event
    public void ShowSkillMenu(SkillManager skillManager, AttributeManager attributeManager)
    {
        var avaliableSkills = skillManager.GetAvaliableSkills(attributeManager);
        while (avaliableSkills.MoveNext())
        {
            var skill = avaliableSkills.Current;

            var skillButtonObject = Instantiate(skillButtonPrefab, transform);
            var skillButton = skillButtonObject.GetComponent<SkillButton>();

            skillButton.skill = skill;
            skillButton.skillManager = skillManager;
            skillButton.attributeManager = attributeManager;

            buttons.Add(skillButtonObject);
        }
    }

    // TODO: This Method has to be wired up to an Event
    public void HideSkillMenu()
    {
        foreach (var button in buttons)
        {
            Destroy(button);
        }
        buttons.Clear();
    }
}
