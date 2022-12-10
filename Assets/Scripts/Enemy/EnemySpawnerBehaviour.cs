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
    int currentMonsterIdx = 0;
    float canSpawnAfter = 0f;
    WaveScriptableObject currentWave;

    void Start()
    {
        if (waves != null)
        {
            currentWave = waves[currentWaveIdx];
            amountOfWaves = waves.Count;
        };
        canSpawnAfter = startSpawningAfter;
    }

    void Update()
    {
        if (isActive && Time.time > canSpawnAfter)
        {
            spawnMonster();
        }
    }

    void spawnMonster()
    {
        GameObject monster = Instantiate(
            currentWave.waveMonsterPrefab,
            transform.position,
            Quaternion.identity
        );

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
            onWaveFinish();
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
            canSpawnAfter = Time.time + currentWave.timeUntilNextWave;
            currentWaveIdx++;
            currentWave = waves[currentWaveIdx];
        }
    }
}
