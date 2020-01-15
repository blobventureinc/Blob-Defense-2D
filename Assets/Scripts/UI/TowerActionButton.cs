using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class TowerActionButton : MonoBehaviour
{
    public Text text;

    private TowerAction _towerAction;
    [HideInInspector]
    public TowerActionMenu towerActionMenu;
    [HideInInspector]
    public Tower tower;
    [HideInInspector]
    public AttributeManager attributeManager;

    private Button button;

    public TowerAction TowerAction {
        get 
        {
            return _towerAction;
        } 
        set 
        {
            _towerAction = value;
            text.text = _towerAction.actionName + " ("+_towerAction.cost+"$)";
        }
    }

    void Start() 
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(DoAction);
        if(TowerAction is PricyTowerAction) 
        {
            attributeManager.gold.onValueChange.AddListener(OnGoldChange);
            OnGoldChange();
        }
    }

    void OnGoldChange()
    {
        if(TowerAction is PricyTowerAction) 
        {
            button.interactable = ((PricyTowerAction) TowerAction).IsDoable(attributeManager);
        }
    }

    void DoAction() 
    {
        _towerAction.DoAction(attributeManager, tower);
        towerActionMenu.HideTowerActionMenu();
    }
}
