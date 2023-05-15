using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [HideInInspector]
    public Objects item;

    public Image image;

    public int count = 1;
    public Text countText;


    [HideInInspector]
    public Transform parentAfterDrag;

    public void Awake() 
    {
        
    }
    //Agregar elementos a nuestro inventario cuando interaccionamos con uno
    public void InitialiseItem(Objects newItem)
    {
        item = newItem;
        image.sprite = newItem.itemSprite;
        count = Random.Range(1,1);
        RefrescarContador();
    }
    
    public void RefrescarContador()
    {
        countText.text = count.ToString();
        bool textActive = count > 1;
        countText.gameObject.SetActive(textActive);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;

    }

    public void Update() 
    {
        //countText.text = "" + count;
    }
}
