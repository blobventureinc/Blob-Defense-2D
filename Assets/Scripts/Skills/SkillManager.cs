using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public Skill[] allSkills;

    [HideInInspector]
    public List<Skill> appliedSkills;

    void OnEnable() 
    {
        appliedSkills = new List<Skill>();
    }

    public IEnumerator<Skill> GetAvaliableSkills(AttributeManager attributeManager) 
    {
        foreach(var skill in allSkills) 
        {
            if(skill.IsApplyable(this, attributeManager)) 
            {
                yield return skill;
            }
        }
    }

    public void Apply(AttributeManager attributeManager, Skill skill) 
    {
        if(skill.Apply(this, attributeManager)) 
        {
            appliedSkills.Add(skill);
        }
    }

    public void DisApply(AttributeManager attributeManager, Skill skill) 
    {
        skill.DisApply(attributeManager);
        appliedSkills.Remove(skill);
    }
}
