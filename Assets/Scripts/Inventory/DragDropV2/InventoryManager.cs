using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public int maxStackItem = 4;
    public InventorySlot[] inventorySlots;

    public GameObject inventoryItemPrefab;
    
    int selectedSlot = -1;

    public Objects[] objetos;

    public void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0) // Seleccion con el scroll.
        {
            int newValue = selectedSlot - (int)(scroll / Mathf.Abs(scroll));
            if (newValue < 0)
            {
                newValue = inventorySlots.Length - 1;
            }
            else if (newValue >= inventorySlots.Length)
            {
                newValue = 0;
            }
            ChangeSelectedSlot(newValue % 5);
        }


    }

    void ChangeSelectedSlot(int newValue)
    {
        if(selectedSlot >= 0) 
            { 
                inventorySlots[selectedSlot].Deselected();
            }
        inventorySlots[newValue].Selected();
        selectedSlot = newValue;
    }
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

    public Objects GetSelectedItem(bool use)
    {
        InventorySlot slot = inventorySlots[selectedSlot];
        DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
        if(itemInSlot != null)
        {
            Objects objects = itemInSlot.item;
            if(use == true)
            {
                itemInSlot.count--;
                if(itemInSlot.count <= 0)
                {
                    Destroy(itemInSlot.gameObject);
                }
                else
                {
                    itemInSlot.RefrescarContador();
                }
            }


            return objects;
        }
        return null;
    }

///AQUI YA NOS RESTA LOS MATERIALES EN EL CRAFTEO FALTA ORGANIZAR LA FORMA EN LA QUE ME QUITA LOS MATERIALES Y QUE SEA POR TODOS LOS SLOTS DE MI INVENTARIO
//Y NO SOLO POR UN SLOT SELECCIONADO
    public Objects GetSelectedItemCrafteo()
    {
        //LA IDEA NUEVA ES SOLO MANDAR A LLAMAR LOS OBJETOS QUE ME RESTARA EL SISTEMA DE CRAFTEO
        //PORQUE EN ESTA VERSION ¿ME ELIMINA EN TOTAL LOS OBJETOS Y NOS POR ORDEN
        for(int i = 0; i < inventorySlots.Length; i++ )
        {
            
            if(inventorySlots[i])
            {
                //Aqui me manda a llamar a todos los slots para posterior mente encontrar el objeto que se pide
                //Debug.Log("Slot " + i);
                InventorySlot slot = inventorySlots[i];
                DraggableItem itemInSlot = slot.GetComponentInChildren<DraggableItem>();
                if(itemInSlot != null)
                {
                    Objects objects = itemInSlot.item;
                    if(objetos[i])
                    {
                        //tenemos que mandar a llamar los elementos que se eliminaran del inventario
                        itemInSlot.count-=10;
                        if(itemInSlot.count <= 0)
                        {
                            Debug.Log(objetos[0]);
                            Destroy(itemInSlot.gameObject); 
                        }
                        
                        else
                        {
                            itemInSlot.RefrescarContador();
                        }

                    }
                    return objects;
                }
            }
        }
    return null;
    }  

}
