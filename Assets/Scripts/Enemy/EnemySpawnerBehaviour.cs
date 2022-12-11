using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemySpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private List<WaveScriptableObject> waves;
    [SerializeField] private float startSpawningAfter = 1f;
    [SerializeField] private PathCreator pathCreator;
    bool isActive = true;
    int amountOfWaves;
    int currentWaveIdx = 0;
    float canSpawnAfter = 0f;
    WaveScriptableObject currentWave;
    // values below are shown in scene manager for debugging purposes
    [SerializeField] private int currentMonsterIdx = 0;
    [SerializeField] private List<GameObject> spawnedMonsters = new List<GameObject>();

    void Start()
    {
        if (waves != null)
        {
            currentWave = waves[currentWaveIdx];
            amountOfWaves = waves.Count;
        }
        canSpawnAfter = startSpawningAfter;
    }

    void Update()
    {
        if (isActive && Time.time > canSpawnAfter)
        {
            spawnMonster();
        }
    }

    public void onMonsterDeath(GameObject monster)
    {
        spawnedMonsters.Remove(monster);
        if (
            currentWave.amountOfEnemiesToSpawn == currentMonsterIdx &&
            spawnedMonsters.Count == 0
        )
        {
            onWaveFinish();
        }
    }

    void spawnMonster()
    {
        GameObject monster = Instantiate(
            currentWave.waveMonsterPrefab,
            transform.position,
            Quaternion.identity
        );
        spawnedMonsters.Add(monster);

        EnemyBehaviour enemyBehaviour = monster.GetComponent<EnemyBehaviour>();
        if (monster.tag != "Boss")
        {
            enemyBehaviour.CurrentHealth *= (currentWaveIdx + 1);
            enemyBehaviour.Speed += 0.2f * (currentWaveIdx + 1);
        }
        if (enemyBehaviour != null)
        {
            enemyBehaviour.pathCreator = pathCreator;
        }

        currentMonsterIdx++;
        if (currentMonsterIdx == currentWave.amountOfEnemiesToSpawn)
        {
            isActive = false;
        }
        else
        {
            canSpawnAfter = Time.time + currentWave.delayBetweenMobs;
        }
    }

    void onWaveFinish()
    {
        currentMonsterIdx = 0;
        Debug.Log("wave " + currentWaveIdx + " is finished");
        if (currentWaveIdx + 1 == waves.Count)
        {
            isActive = false;
            Debug.Log("move to next lvl");
        }
        else
        {
            GameObject.Find("PowerUpManager").GetComponent<PowerUpsManager>().offerPowerUp();
            isActive = true;
            canSpawnAfter = Time.time + currentWave.timeUntilNextWave;
            currentWaveIdx++;
            currentWave = waves[currentWaveIdx];
        }
    }
}
