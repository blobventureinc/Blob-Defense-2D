using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SkillButton : MonoBehaviour
{
    public Text text;

    [HideInInspector]
    public Skill skill;
    [HideInInspector]
    public SkillManager skillManager;
    [HideInInspector]
    public AttributeManager attributeManager;

    void Start() 
    {
        GetComponent<Button>().onClick.AddListener(DoAction);
    }

    void DoAction() 
    {
        skillManager.Apply(attributeManager, skill);
    }
}
