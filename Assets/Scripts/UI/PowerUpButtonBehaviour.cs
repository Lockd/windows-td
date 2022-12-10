using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpButtonBehaviour : MonoBehaviour
{
    [SerializeField] private PowerUpWindowBehaviour powerUpWindow;
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private Image iconImage;
    public PowerUpScriptableObject activePowerUp;

    void Start()
    {
        Button selectButton = GetComponent<Button>();
        selectButton.onClick.AddListener(onSelect);
    }

    public void addPowerUp(PowerUpScriptableObject powerUp)
    {
        Debug.Log("power up is added ");
        activePowerUp = powerUp;
        title.text = activePowerUp.title;
        iconImage.sprite = activePowerUp.sprite;
    }

    public void onSelect()
    {
        description.text = activePowerUp.description;
        powerUpWindow.selectedPowerUp = activePowerUp;
    }
}