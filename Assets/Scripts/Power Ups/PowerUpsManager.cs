using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class modifiers
{
    public int additionalDamage = 0;
    public float shotCooldownReduction = 0f;
    public float additionalFreezeTime = 0f;
    public int additionalTagets = 0;
    public float additionalRange = 0f;
}

public class PowerUpsManager : MonoBehaviour
{
    [SerializeField] private List<PowerUpScriptableObject> allPowerUps;
    [SerializeField] private PowerUpWindowBehaviour powerUpWidnow;
    [SerializeField] private int amountOfPowerUpsToOffer = 3;
    List<PowerUpScriptableObject> nonSelectedPowerUps;
    public static Hashtable modifiersList = new Hashtable();
    string[] allPowerUpTypes = { "Excel", "PowerPoint", "Word", "Chrome", "Explorer" };

    void Start()
    {
        foreach (string type in allPowerUpTypes)
        {
            modifiersList.Add(type, new modifiers());
        }
    }

    public void offerPowerUp()
    {
        powerUpWidnow.gameObject.SetActive(true);
        powerUpWidnow.powerUps = getPowerUps();
        powerUpWidnow.onEnable();
        Time.timeScale = 0;
    }

    void onChangeModifiers(PowerUpScriptableObject powerUp, string targetTower)
    {
        modifiers currentMods = (modifiers)modifiersList[targetTower];
        currentMods.additionalDamage += powerUp.additionalDamage;
        currentMods.shotCooldownReduction += powerUp.shotCooldownReduction;
        currentMods.additionalFreezeTime += powerUp.additionalFreezeTime;
        currentMods.additionalTagets += powerUp.additionalTagets;
        currentMods.additionalRange += powerUp.additionalRange;
    }

    public void applyPowerUp(PowerUpScriptableObject powerUp)
    {
        string targetTower = powerUp.targetTower + "";
        if (targetTower == "All")
        {
            foreach (string type in allPowerUpTypes)
            {
                onChangeModifiers(powerUp, type);
            }
        }
        else
        {
            onChangeModifiers(powerUp, targetTower);
        }
    }

    List<PowerUpScriptableObject> getPowerUps()
    {
        List<PowerUpScriptableObject> powerUpsToOffer = new List<PowerUpScriptableObject>();
        nonSelectedPowerUps = allPowerUps;

        int upTo;

        if (nonSelectedPowerUps.Count >= amountOfPowerUpsToOffer) upTo = amountOfPowerUpsToOffer;
        else upTo = nonSelectedPowerUps.Count;

        for (int i = 0; i < upTo; i++)
        {
            int powerUpIdx = Random.Range(0, nonSelectedPowerUps.Count);
            PowerUpScriptableObject powerUp = nonSelectedPowerUps[powerUpIdx];

            powerUpsToOffer.Add(powerUp);
            nonSelectedPowerUps.Remove(powerUp);
        }

        return powerUpsToOffer;
    }
}