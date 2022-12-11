using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingText : MonoBehaviour
{
    [SerializeField] private float maxScale = 1.1f;
    [SerializeField] private float speed = .1f;
    Vector3 initialScale;
    bool isGrowing = true;

    void Start()
    {
        initialScale = transform.localScale;
    }

    void FixedUpdate()
    {
        float currentScale = transform.localScale.x;

        float growBy = speed * Time.deltaTime;
        if (!isGrowing) growBy *= -1;

        transform.localScale = new Vector3(
            growBy + currentScale,
            growBy + currentScale,
            1f
        );

        if (currentScale > maxScale) isGrowing = false;
        if (currentScale < initialScale.x) isGrowing = true;
    }
}
