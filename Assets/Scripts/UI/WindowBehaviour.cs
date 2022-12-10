using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowBehaviour : MonoBehaviour
{
    [SerializeField] private List<GameObject> towerPrefabs;
    public Button closeButton;
    public GameObject currentExe;
    public GameObject[] towerTexts;
    public Button buildButton;
    public int currentTower = -1;

    void Start()
    {
        closeButton.onClick.AddListener(CloseWindow);
        buildButton.onClick.AddListener(BuildTower);
    }

    void Update()
    {
        buildButton.gameObject.SetActive(currentTower >= 0);
        if (currentTower == -1)
        {
            foreach (GameObject obj in towerTexts)
            {
                obj.SetActive(false);
            }
        }
    }

    void CloseWindow()
    {
        currentTower = -1;
        currentExe = null;
        gameObject.SetActive(false);
    }

    void BuildTower()
    {
        // getting parent transform since we are insterested in position of container
        Instantiate(
            towerPrefabs[currentTower],
            currentExe.transform.position,
            currentExe.transform.rotation
        );
        Destroy(currentExe);
        CloseWindow();
    }
}
