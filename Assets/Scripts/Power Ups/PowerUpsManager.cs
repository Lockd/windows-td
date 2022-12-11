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
    [SerializeField] private GameObject buildTowerPrefab;
    List<PowerUpScriptableObject> nonSelectedPowerUps;
    public List<GameObject> emptyFolders = new List<GameObject>();
    public static Hashtable modifiersList = new Hashtable();
    string[] allPowerUpTypes = { "Excel", "PowerPoint", "Word", "Chrome", "Explorer" };

    void Start()
    {
        GameObject[] allEmptyFolders = GameObject.FindGameObjectsWithTag("Empty Folder");
        emptyFolders.AddRange(allEmptyFolders);

        addNewTower(2);

        if (modifiersList.Count == 0)
        {
            foreach (string type in allPowerUpTypes)
            {
                modifiersList.Add(type, new modifiers());
            }
        }
    }

    public void offerPowerUp()
    {
        powerUpWidnow.gameObject.SetActive(true);
        powerUpWidnow.powerUps = getPowerUps();
        powerUpWidnow.onEnable();
        Time.timeScale = 0;
    }

    public void addNewTower(int amountToBeAdded)
    {
        for (int i = 0; i < amountToBeAdded; i++)
        {
            int towerIdxToAdd = Random.Range(0, emptyFolders.Count);

            GameObject folderToBeReplaced = emptyFolders[towerIdxToAdd];
            emptyFolders.Remove(folderToBeReplaced);
            Instantiate(
                buildTowerPrefab,
                folderToBeReplaced.transform.position,
                folderToBeReplaced.transform.rotation
            );
            Destroy(folderToBeReplaced);
        }
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
        switch (targetTower)
        {
            case "Generic":
                if (powerUp.spawnAdditionalTowers != 0)
                {
                    addNewTower(powerUp.spawnAdditionalTowers);
                }
                break;
            case "All":
                foreach (string type in allPowerUpTypes)
                {
                    onChangeModifiers(powerUp, type);
                }
                break;
            default:
                onChangeModifiers(powerUp, targetTower);
                break;
        }
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