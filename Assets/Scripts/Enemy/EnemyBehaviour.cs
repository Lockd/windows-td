using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 0.2f;
    [SerializeField] private PathCreator pathCreator;
    float distanceTravelled = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        distanceTravelled += speed * Time.fixedDeltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
        // transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
    }
}
