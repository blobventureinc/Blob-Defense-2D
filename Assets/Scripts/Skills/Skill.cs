using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Skill: ScriptableObject
{
    public int skillPoints;
    public Skill[] dependantSkills;

    public bool IsApplyable(SkillManager skillManager, AttributeManager attributeManager) 
    {
        foreach(var skill in dependantSkills) 
        {
            if(!skillManager.appliedSkills.Contains(skill)) 
            {
                return false;
            }
        }
        return attributeManager.skillPoints.value >= skillPoints;
    }

    public bool Apply(SkillManager skillManager, AttributeManager attributeManager)
    {
        if(IsApplyable(skillManager, attributeManager)) 
        {
            attributeManager.skillPoints.Decrease(skillPoints);
            ApplyImpl();
            return true;
        }
        else
        {
            return false;
        }
    }

    protected abstract void ApplyImpl();

    public void DisApply(AttributeManager attributeManager) 
    {
        attributeManager.skillPoints.Increase(skillPoints);
        DisApplyImpl();
    }

    protected abstract void DisApplyImpl();
}
