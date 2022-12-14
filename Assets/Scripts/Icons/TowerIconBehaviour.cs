using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIconBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject TowerRangeIndicator;
    public SpriteRenderer rend;
    public GameObject frame;
    bool isSelected;
    public bool isHovering;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && (!isHovering))
        {
            rend.color = new Color(0.2971698f, 0.741266f, 1f, 0);
            frame.SetActive(false);

            if (TowerRangeIndicator != null) TowerRangeIndicator.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        if (!isSelected)
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
        if (TowerRangeIndicator != null) TowerRangeIndicator.SetActive(true);
    }

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
