using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    public PathCreator pathCreator;
    [SerializeField] private int currentHelath = 20;
    float distanceTravelled = 0f;
    float restoreSpeedAfter = 0f;
    float speedModifier = 1f;

    void FixedUpdate()
    {
        if (Time.time > restoreSpeedAfter && speedModifier != 1f)
        {
            speedModifier = 1f;
        }
        distanceTravelled += (speed * speedModifier) * Time.fixedDeltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
    }

    public void onGetDamage(int amount)
    {
        currentHelath -= amount;
        if (currentHelath <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void onApplySlow(float speedReduction, float duration, bool isStun)
    {
        restoreSpeedAfter = Time.time + duration;
        if (speedModifier == 1f || isStun)
        {
            speedModifier -= speedReduction;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Base")
        {
            Destroy(gameObject);
            // TODO Trigger game over screen here
        }
    }
}
