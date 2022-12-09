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
    // Start is called before the first frame update
    void Start()
    {
        selectButton.onClick.AddListener(OnTowerSelect);
        windowBeh = window.GetComponent<WindowBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTowerSelect()
    {
        foreach(GameObject obj in windowBeh.towerTexts)
        {
            obj.SetActive(false);
        }
        windowBeh.towerTexts[towerIndex].SetActive(true);
        windowBeh.currentTower = towerIndex;
    }
}
