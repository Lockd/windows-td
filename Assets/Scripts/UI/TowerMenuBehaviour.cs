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
    // Start is called before the first frame update
    void Start()
    {
        deleteButton.onClick.AddListener(DeleteTower);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DeleteTower()
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
