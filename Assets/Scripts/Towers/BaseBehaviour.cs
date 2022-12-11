using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    public GameObject bsod;
    int maxHp = 3;
    [SerializeField] int currentHp;

    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        if (currentHp <= 0 && !bsod.activeSelf) bsod.SetActive(true);
    }

    public int CurrentHp
    {
        get
        {
            return currentHp;
        }
        set
        {
            currentHp = value;
        }
    }
}
