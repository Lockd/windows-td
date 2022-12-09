using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowBehaviour : MonoBehaviour
{
    public Button closeButton;

    public GameObject currentExe;

    public GameObject[] towerTexts;

    public Button buildButton;

    public int currentTower = -1;

    public GameObject towerTemp;

    public Sprite[] towerSprites;
    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(CloseWindow);
        buildButton.onClick.AddListener(BuildTower);
    }

    // Update is called once per frame
    void Update()
    {
        buildButton.gameObject.SetActive(currentTower >= 0);
        if (currentTower == -1)
        {
            foreach(GameObject obj in towerTexts)
            {
                obj.SetActive(false);
            }
        }
    }

    void CloseWindow()
    {
        // Destroy(gameObject);
        currentTower = -1;
        currentExe = null;
        gameObject.SetActive(false);
    }

    void BuildTower()
    {
        CloseWindow();
        Instantiate(towerTemp, transform.position, transform.rotation);
        towerTemp.GetComponent<SpriteRenderer>().sprite = towerSprites[currentTower];
    }
}
