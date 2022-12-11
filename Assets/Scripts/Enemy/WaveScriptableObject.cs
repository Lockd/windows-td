using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/WavePattern", order = 1)]
public class WaveScriptableObject : ScriptableObject
{
    public float delayBetweenMobs = .5f;
    public float timeUntilNextWave = 1.5f;
    public GameObject waveMonsterPrefab;
    public int amountOfEnemiesToSpawn = 10;
    public bool shouldOfferPowerUp = false;
}
