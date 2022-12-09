using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderBehaviour : MonoBehaviour
{

    public SpriteRenderer rend;

    public GameObject frame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) OnRightMouseClick();
    }

    private void OnMouseEnter()
    {
        Debug.Log(gameObject.name + " detected");
        rend.color = new Color(0.2971698f, 0.741266f, 1f, 0.12f);
        frame.SetActive(true);
    }

    private void OnMouseExit()
    {
        Debug.Log(gameObject.name + " undetected");
        rend.color = new Color(0.2971698f, 0.741266f, 1f, 0);
        frame.SetActive(false);
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name + " left clicked");
        rend.color = new Color(0.2971698f, 0.741266f, 1f, 0.34f);
    }

    private void OnRightMouseClick()
    {
        Debug.Log(gameObject.name + " right clicked");
        rend.color = new Color(0.2971698f, 0.741266f, 1f, 0.34f);
    }
}
