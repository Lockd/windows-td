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

    void FixedUpdate()
    {
        distanceTravelled += speed * Time.fixedDeltaTime;
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Base")
        {
            Destroy(gameObject);
            // TODO Trigger game over screen here
        }
    }
}
