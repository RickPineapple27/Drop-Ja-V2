using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image image;

    public Color selectedColor, notSelectedColor;


    private void Awake()
    {
        Deselected();
    }
    
    public void Start()
    {
    }
    public void Selected()
    {
        image.color = selectedColor;
    }

    public void Deselected()
    {
        image.color = notSelectedColor;

    }

    public void OnDrop(PointerEventData eventData)
    {
        //GameObject dropped = eventData.pointerDrag;
        //DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        //draggableItem.parentAfterDrag = transform;
        if(transform.childCount == 0)
        {
            DraggableItem draggableItem = eventData.pointerDrag.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }
    }

}
