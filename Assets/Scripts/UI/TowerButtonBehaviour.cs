using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonBehaviour : MonoBehaviour
{
    public int towerIndex;
    public Button selectButton;
    public WindowBehaviour windowBeh;
    [TextArea] public string descriptionText;

    void Start()
    {
        selectButton.onClick.AddListener(OnTowerSelect);
    }

    void OnTowerSelect()
    {
        windowBeh.descriptionField.text = descriptionText;
        windowBeh.currentTower = towerIndex;
    }
}