using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpWindowBehaviour : MonoBehaviour
{
    public List<PowerUpScriptableObject> powerUps;
    [SerializeField] private GameObject powerUpCardsContainer;
    public PowerUpScriptableObject selectedPowerUp;
    [SerializeField] private AudioSource errorAudio;
    [SerializeField] private PowerUpsManager powerUpsManager;
    [SerializeField] private GameObject selectButton;
    public TextMeshProUGUI desc;

    void Update()
    {
        if (selectedPowerUp != null && !selectButton.activeInHierarchy)
        {
            selectButton.SetActive(true);
        }
    }

    public void onSelectPowerUp()
    {
        Time.timeScale = 1;
        powerUpsManager.applyPowerUp(selectedPowerUp);
        selectedPowerUp = null;
        desc.text = "";
        gameObject.SetActive(false);
    }

    public void onEnable()
    {
        selectButton.SetActive(false);
        Time.timeScale = 0;
        for (int i = 0; i < powerUps.Count; i++)
        {
            GameObject childGameObject = powerUpCardsContainer.transform.GetChild(i).gameObject;
            PowerUpButtonBehaviour powerUpButton = childGameObject.GetComponent<PowerUpButtonBehaviour>();
            if (powerUpButton != null) powerUpButton.addPowerUp(powerUps[i]);
        }
    }

    public void playErrorSound()
    {
        errorAudio.Play();
    }
}

