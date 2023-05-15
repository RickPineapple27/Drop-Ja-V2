using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelCrafteoController : MonoBehaviour
{
    public GameObject cerrarMesaCrafteo;
    public GameObject PanelInfoFiltro1;
    public GameObject PanelInfoFiltro2;
    public GameObject PanelInfoFiltro3;
    public GameObject PanelInfoFiltro4;

    public GameObject MesaCrafteo;

    public GameObject player;

    public GameObject[] objeto;

    public Transform CraftPos;
        
    public InventoryManager inventoryManager;
    //public GameObject itemPrefab;    


    public void AbrirInfoFiltro1()
    {
        PanelInfoFiltro1.SetActive(true);
        PanelInfoFiltro2.SetActive(false);
        PanelInfoFiltro3.SetActive(false);
        PanelInfoFiltro4.SetActive(false);
    }
    public void CerrarInfoFiltro1()
    {
        PanelInfoFiltro1.SetActive(false);
    }

    public void AbrirInfoFiltro2()
    {
        PanelInfoFiltro2.SetActive(true);
        PanelInfoFiltro1.SetActive(false);
        PanelInfoFiltro3.SetActive(false);
        PanelInfoFiltro4.SetActive(false);
    }
    public void CerrarInfoFiltro2()
    {
        PanelInfoFiltro2.SetActive(false);
    }

    public void AbrirInfoFiltro3()
    {
        PanelInfoFiltro3.SetActive(true);
        PanelInfoFiltro1.SetActive(false);
        PanelInfoFiltro2.SetActive(false);
        PanelInfoFiltro4.SetActive(false);
    }
    public void CerrarInfoFiltro3()
    {
        PanelInfoFiltro3.SetActive(false);
    }

    public void AbrirInfoFiltro4()
    {
        PanelInfoFiltro4.SetActive(true);
        PanelInfoFiltro1.SetActive(false);
        PanelInfoFiltro2.SetActive(false);
        PanelInfoFiltro3.SetActive(false);
    }
    public void CerrarInfoFiltro4()
    {
        PanelInfoFiltro4.SetActive(false);
    }


    public void CerarMesaCrafteo()
    {
        MesaCrafteo.GetComponent<Objeto>().DesactivarObjeto();
        cerrarMesaCrafteo.SetActive(false);

    }

//Con este metodo se manda a llamar a el inventory manager y a su metodo que nos 
//permite eliminar los materiales del inventario pero falta hacer que me elimine los materiales especificados y 
//que me organice LA FORMA EN LA QUE ME QUITA LOS MATERIALES Y QUE SEA POR TODOS LOS SLOTS DE MI INVENTARIO
//Y NO SOLO POR UN SLOT SELECCIONADO
    public void CrearObjeto1(int id)
    {
       
        //Aqui estamos devolviendo el nombre del objeto desde el scriptableObject y lo mandamos a traer por su id desde el boton
        Objects receivedItem = inventoryManager.GetSelectedItemCrafteo();
        if (receivedItem != null)
        {
            //Mandamos a el inventory manager y nos resta lo que tengamos en el inventario
            Debug.Log("Crafteo completado" + receivedItem);
            //Debug.Log(objeto[id].GetComponent<ObjectType>().objectType);
            //aqui instanciamos el objeto que querramos construir
            Instantiate(objeto[id], CraftPos.position, CraftPos.rotation, null);
        }
        else
        {
            Debug.Log("No hay materiales suficientes");

        }
    }






}
