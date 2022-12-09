using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private PathCreator pathCreator;
    float distanceTravelled = 0f;

    void FixedUpdate()
    {
        distanceTravelled += speed * Time.fixedDeltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Base")
        {
            // Trigger game over screen here
            Debug.Log("Zadeli hatu");
        }
    }
}
