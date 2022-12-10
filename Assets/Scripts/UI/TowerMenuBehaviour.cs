using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TowerMenuBehaviour : MonoBehaviour, IPointerEnterHandler
{
    public Button deleteButton;
    public TowerIconBehaviour thisTowerIcon;
    public GameObject defaultExe;
    public GameObject thisTower;

    void Start()
    {
        // moved that logic to UI button on click event
        // deleteButton.onClick.AddListener(DeleteTower);
    }

    public void DeleteTower()
    {
        Debug.Log("Tower Deleted");
        Instantiate(defaultExe, thisTower.transform.position, transform.rotation);
        Destroy(thisTower);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("MouseOver");
        thisTowerIcon.isHovering = true;
        //do stuff
    }
}
