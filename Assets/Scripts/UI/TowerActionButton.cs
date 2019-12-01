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

    public TowerAction TowerAction {
        get 
        {
            return _towerAction;
        } 
        set 
        {
            _towerAction = value;
            text.text = _towerAction.name;
        }
    }

    void Start() 
    {
        GetComponent<Button>().onClick.AddListener(DoAction);
    }

    void DoAction() 
    {
        _towerAction.DoAction(attributeManager, tower);
        towerActionMenu.HideTowerActionMenu();
    }
}
