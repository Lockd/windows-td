using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    public PathCreator pathCreator;
    [SerializeField] private int currentHelath = 20;
    float distanceTravelled = 0f;
    float restoreSpeedAfter = 0f;
    float speedModifier = 1f;
    public Slider HPBar;
    public string enemyID;
    EnemySpawnerBehaviour spawnerBehaviour;

    private void Start()
    {
        spawnerBehaviour = GameObject.FindObjectsOfType<EnemySpawnerBehaviour>()[0];
        HPBar.minValue = 0;
        HPBar.maxValue = currentHelath;
        HPBar.value = HPBar.maxValue;
    }
    void FixedUpdate()
    {
        HPBar.value = currentHelath;
        if (Time.time > restoreSpeedAfter && speedModifier != 1f)
        {
            speedModifier = 1f;
        }
        distanceTravelled += (speed * speedModifier) * Time.fixedDeltaTime;
        if (enemyID != "macBoss")
        {
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        }
        else
        {
            Transform target = GameObject.FindGameObjectWithTag("Base").transform;
            transform.position = Vector3.MoveTowards(transform.position, target.position, (speed * speedModifier) * Time.fixedDeltaTime);
        }
    }

    public void onGetDamage(int amount)
    {
        currentHelath -= amount;
        if (currentHelath <= 0)
        {
            onEnemyDeath();
        }
    }

    public void onApplySlow(float speedReduction, float duration, bool isStun)
    {
        restoreSpeedAfter = Time.time + duration;
        if (speedModifier == 1f || isStun)
        {
            speedModifier -= speedReduction;
        }
        if (speedModifier < 0)
        {
            speedModifier = 0;
        }
    }

    void onEnemyDeath()
    {
        spawnerBehaviour.onMonsterDeath(gameObject);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Base")
        {
            if (gameObject.tag == "Boss")
            {
                collider.GetComponent<BaseBehaviour>().CurrentHp -= 2;
            }
            else
            {
                collider.GetComponent<BaseBehaviour>().CurrentHp--;
            }

            onEnemyDeath();
        }
    }

    public int CurrentHealth
    {
        get
        {
            return currentHelath;
        }

        set
        {
            currentHelath = value;
        }
    }
    public float Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }
}
