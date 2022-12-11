using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerUpWindowBehaviour : MonoBehaviour
{
    public List<PowerUpScriptableObject> powerUps;
    [SerializeField] private GameObject powerUpCardsContainer;
    public PowerUpScriptableObject selectedPowerUp;
    [SerializeField] private AudioSource errorAudio;
    [SerializeField] private PowerUpsManager powerUpsManager;
    public TextMeshProUGUI desc;

    // TODO fix the bug with select button available before power up is selected

    public void onSelectPowerUp()
    {
        Debug.Log("power up window should be closed");
        Time.timeScale = 1;
        powerUpsManager.applyPowerUp(selectedPowerUp);
        selectedPowerUp = null;
        desc.text = "";
        gameObject.SetActive(false);
    }

    public void onEnable()
    {
        Debug.Log("power up window is enabled");
        Time.timeScale = 0;
        for (int i = 0; i < powerUps.Count; i++)
        {
            GameObject childGameObject = powerUpCardsContainer.transform.GetChild(i).gameObject;
            Debug.Log(childGameObject.name);
            PowerUpButtonBehaviour powerUpButton = childGameObject.GetComponent<PowerUpButtonBehaviour>();
            if (powerUpButton != null) powerUpButton.addPowerUp(powerUps[i]);
        }
    }

    public void playErrorSound()
    {
        errorAudio.Play();
    }
}

