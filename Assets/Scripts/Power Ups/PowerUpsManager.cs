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
    public static Hashtable test = new Hashtable();

    void Start()
    {
        //offerPowerUp();
        test.Add("Excel", new modifiers());
        test.Add("PowerPoint", new modifiers());
        test.Add("Word", new modifiers());
        test.Add("Chrome", new modifiers());
        test.Add("Explorer", new modifiers());
    }

    public void offerPowerUp()
    {
        powerUpWidnow.gameObject.SetActive(true);
        powerUpWidnow.powerUps = getPowerUps();
        powerUpWidnow.onEnable();
        Time.timeScale = 0;
    }

    public void applyPowerUp(PowerUpScriptableObject powerUp)
    {
        // TODO VLADIK adjust this logic
        Debug.Log("should apply power up");
        modifiers currentMods = (modifiers)test[""+ powerUp.targetTower];
        currentMods.additionalDamage += powerUp.additionalDamage;
        currentMods.shotCooldownReduction += powerUp.shotCooldownReduction;
        currentMods.additionalFreezeTime += powerUp.additionalFreezeTime;
        currentMods.additionalTagets += powerUp.additionalTagets;
        currentMods.additionalRange += powerUp.additionalRange;
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