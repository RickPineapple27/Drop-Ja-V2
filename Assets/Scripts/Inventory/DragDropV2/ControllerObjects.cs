using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerObjects : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Objects[] objects;

    public Animator PersonajeV2;

    private InterfaceController iController;

    public void Start()
    {
        PersonajeV2 = GetComponent<Animator>();
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
            Debug.Log("No se agrego porque no hay espacio");
        }
    }
    //METODO PARA SELECCIONAR OBJETOS DE NUESTRO INVENTARIO (ponerlos en la mano del player)
    public void SeleccionarItem()
    {
        Objects receivedItem = inventoryManager.GetSelectedItem(false);
        if (receivedItem != null)
        {
            Debug.Log("Objeto seleccionado" + receivedItem);
        }else{
            Debug.Log("No hay objeto");

        }
    }

    public void UseSelectedItem()
    {   //Metodo para usar ciertos objetos en la escena entregar o construir como en minecraft y nos ira restando elementos tambien se usan cuando el jugador consume algo o se cura
        Objects receivedItem = inventoryManager.GetSelectedItem(true);
        if (receivedItem != null)
        {
            //Mandamos a llamar a que se nos sume la vida
            //Mandamos a llamar a que se nos sume la barra de hambre
            //mandamos a sumar la vida cada que usamos el botiquin
            Debug.Log("Tomar agua, comida, etc.. " + receivedItem);
        }
        else
        {
            Debug.Log("No hay objeto para usar");

        }
    }


    void Update()
    {
        //textoSlots.text = slotAmount.ToString();
        //textoSlots.text = slotAmount + " ";
        PersonajeV2.SetBool("Interaction", false);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out hit, 20f))
        {
            if (hit.collider.tag == "Item")
            {
                iController.itemText.text = "Presiona (Q) para coleccionar " + hit.transform.GetComponent<ObjectType>().objectType.itemName;

                if (Input.GetButtonDown("Fire3"))//B en Gamepad
                {
                    for (int i = 0; i < objects.Length; i++)
                    {
                        if (objects[i] == null || objects[i].name == hit.transform.GetComponent<ObjectType>().objectType.name)
                        {
                            //Vamos a nuestro inventory manager y traemos el metodo de agregar item
                            bool results = inventoryManager.AddItem(objects[i]);
                        

                            
                            PersonajeV2.SetBool("Interaction", true);

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
