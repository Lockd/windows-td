using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseBehaviour : MonoBehaviour
{
    int maxHp = 3;
    [SerializeField] int currentHp;

    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        if (currentHp <= 0) SceneManager.LoadScene("BSOD");
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
