using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WindowBehaviour : MonoBehaviour
{
    [SerializeField] private List<GameObject> towerPrefabs;
    public GameObject currentExe;
    public TMP_Text descriptionField;
    public Button buildButton;
    public int currentTower = -1;

    void Update()
    {
        buildButton.gameObject.SetActive(currentTower >= 0);
        if (currentTower == -1)
        {
            descriptionField.text = "";
        }
    }

    public void CloseWindow()
    {
        currentTower = -1;
        currentExe = null;
        gameObject.SetActive(false);
    }

    public void BuildTower()
    {
        Instantiate(
            towerPrefabs[currentTower],
            currentExe.transform.position,
            currentExe.transform.rotation
        );
        Destroy(currentExe);
        CloseWindow();
    }
}
