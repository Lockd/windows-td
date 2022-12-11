using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskbarBehaviour : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject powerupMenu;
    [SerializeField] private GameObject towerBuildMenu;
    [SerializeField] private AudioSource errorSound;
    void Start()
    {
        startMenu.SetActive(false);
        startButton.onClick.AddListener(onClickStartMenu);
    }

    void onClickStartMenu()
    {
        if (
            powerupMenu.activeInHierarchy ||
            towerBuildMenu.activeInHierarchy
        )
        {
            errorSound.Play();
            return;
        }

        float currentTimeScale = Time.timeScale;

        if (currentTimeScale == 1) Time.timeScale = 0;
        else Time.timeScale = 1;

        startMenu.SetActive(!startMenu.activeInHierarchy);
    }
}
