using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    public GameObject bsod;

    int maxHp = 3;

    [SerializeField] int currentHp;
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    // Update is called once per frame
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
    // Instantiate(bsod, bsod.transform.position, bsod.transform.rotation);
}
