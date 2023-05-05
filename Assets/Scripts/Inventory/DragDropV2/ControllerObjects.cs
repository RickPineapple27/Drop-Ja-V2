using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerObjects : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Objects[] objects;


    private InterfaceController iController;

    public void Start()
    {
        iController = FindObjectOfType<InterfaceController>();
    }
    public void PickupItem(int id)
    {
        bool results = inventoryManager.AddItem(objects[id]);
        if (results == true) 
        {
            //Debug.Log("item agregado");
        }
        else
        {
            //Aqui podriamos mandar a activar un texto que nos diga que no hay mas espacio en el inventario
            //Debug.Log("No se agrego porque no hay espacio");
        }
    }


    void Update()
    {
        //textoSlots.text = slotAmount.ToString();
        //textoSlots.text = slotAmount + " ";

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, 20f))
        {
            if (hit.collider.tag == "Item")
            {
                iController.itemText.text = "Presiona (B) para coleccionar " + hit.transform.GetComponent<ObjectType>().objectType.itemName;

                if (Input.GetButtonDown("Fire3"))//B en Gamepad
                {
                    for (int i = 0; i < objects.Length; i++)
                    {
                        if (objects[i] == null || objects[i].name == hit.transform.GetComponent<ObjectType>().objectType.name)
                        {
                            //Vamos a nuestro inventory manager y traemos el metodo de agregar item
                            bool results = inventoryManager.AddItem(objects[i]);
                            Destroy(hit.transform.gameObject);
                            break;
                        }
                    }
                }
            }
            else if (hit.collider.tag != "Item")
            {
                iController.itemText.text = null;
            }
        }
    }
}
