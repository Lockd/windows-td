using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FolderBehaviour : MonoBehaviour
{

    float doubleClickTime = .5f, lastClickTime;

    public SpriteRenderer rend;

    public GameObject frame;

    bool isSelected;

    public GameObject execWindow;

    bool isHovering;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isHovering)
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= doubleClickTime)
            {
                execWindow.SetActive(true);
                execWindow.GetComponent<WindowBehaviour>().currentExe = gameObject;
            }

            lastClickTime = Time.time;
        } else if (Input.GetMouseButtonDown(0) && (!isHovering))
        {
            rend.color = new Color(0.2971698f, 0.741266f, 1f, 0);
            frame.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        if(!isSelected)
            rend.color = new Color(0.2971698f, 0.741266f, 1f, 0.12f);
        else
            rend.color = new Color(0.2971698f, 0.741266f, 1f, 0.34f);
        frame.SetActive(true);
    }

    private void OnMouseExit()
    {
        if (!isSelected)
        {
            rend.color = new Color(0.2971698f, 0.741266f, 1f, 0);
            frame.SetActive(false);
        }
        else
        {
            rend.color = new Color(0.2971698f, 0.741266f, 1f, 0.24f);
        }
        isHovering = false;
    }

    private void OnMouseOver()
    {
        isHovering = true;
    }

    private void OnMouseDown()
    {
        GameObject[] icons = GameObject.FindGameObjectsWithTag("Icon");
        foreach (GameObject obj in icons)
        {
            FolderBehaviour folder = obj.GetComponent<FolderBehaviour>();
            TowerIconBehaviour iconBeh = obj.GetComponent<TowerIconBehaviour>();
            if (folder != null)
            {
                folder.frame.SetActive(false);
                folder.IsSelected = false;
            }
            if (iconBeh != null)
            {
                iconBeh.frame.SetActive(false);
                iconBeh.IsSelected = false;
            }
            obj.GetComponent<SpriteRenderer>().color = new Color(0.2971698f, 0.741266f, 1f, 0);
        }
        rend.color = new Color(0.2971698f, 0.741266f, 1f, 0.34f);
        frame.SetActive(true);
        isSelected = true;
    }

    /*private void OnRightMouseClick()
    {
        Debug.Log(gameObject.name + " right clicked");
        rend.color = new Color(0.2971698f, 0.741266f, 1f, 0.34f);
    }*/

    public bool IsSelected
    {
        get
        {
            return isSelected;
        }
        set
        {
            isSelected = value;
        }
    }
}
