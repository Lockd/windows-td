using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButtonBehaviour : MonoBehaviour
{
    public int towerIndex;
    public Button selectButton;
    public GameObject window;
    WindowBehaviour windowBeh;

    void Start()
    {
        selectButton.onClick.AddListener(OnTowerSelect);
        windowBeh = window.GetComponent<WindowBehaviour>();
    }

    void OnTowerSelect()
    {
        foreach (GameObject obj in windowBeh.towerTexts)
        {
            obj.SetActive(false);
        }
        windowBeh.towerTexts[towerIndex].SetActive(true);
        windowBeh.currentTower = towerIndex;
    }
}
