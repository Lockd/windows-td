using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsManager : MonoBehaviour
{
    [SerializeField] private List<PowerUpScriptableObject> allPowerUps;
    [SerializeField] private PowerUpWindowBehaviour powerUpWidnow;
    [SerializeField] private int amountOfPowerUpsToOffer = 3;
    List<PowerUpScriptableObject> nonSelectedPowerUps;

    void Start()
    {
        offerPowerUp();
    }

    public void offerPowerUp()
    {
        powerUpWidnow.gameObject.SetActive(true);
        powerUpWidnow.powerUps = getPowerUps();
        powerUpWidnow.onEnable();
    }

    public void applyPowerUp(PowerUpScriptableObject powerUp)
    {
        // TODO add this logic
        Debug.Log("should apply power up");
        Debug.Log(powerUp);
    }

    List<PowerUpScriptableObject> getPowerUps()
    {
        List<PowerUpScriptableObject> powerUpsToOffer = new List<PowerUpScriptableObject>();
        nonSelectedPowerUps = allPowerUps;

        for (int i = 0; i < amountOfPowerUpsToOffer; i++)
        {
            int powerUpIdx = Random.Range(0, nonSelectedPowerUps.Count);
            PowerUpScriptableObject powerUp = nonSelectedPowerUps[powerUpIdx];

            powerUpsToOffer.Add(powerUp);
            nonSelectedPowerUps.Remove(powerUp);
        }

        return powerUpsToOffer;
    }
}