using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public int maxStackItem = 4;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;


    //En este metodo coprobamos que el objetos con el que interactuamos se coloque en un slot vacio
    public bool AddItem(Objects item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            //Objetos encimados en stack
            InventorySlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackItem && itemInSlot.item.stackable == true)
            {

                itemInSlot.count++;
                itemInSlot.RefrescarContador();
                return true;
            }
        }
        //objetos individuales
        for (int i = 0; i < inventorySlots.Length; i++) 
        {
            InventorySlot slot = inventorySlots[i];
            DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
            if (itemInSlot == null) 
            {
               SpawnNewItem(item, slot);
                return true;
            }
        }
        return false;
    }
    //En este metodo ponemos el objeto en el slot vacio
    void SpawnNewItem(Objects item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        DraggableItem draggableItem = newItemGo.GetComponent<DraggableItem>();
        draggableItem.InitialiseItem(item);
    }
}
