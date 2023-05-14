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
        
    public InventorySlot[] inventorySlots;
    
    public GameObject prefabItem;
    //VALORES A RESTAR
    public int piedra=50;
    public int carbon=50;
    public int roca=50;

    
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

    public void CrearObjeto1(int id)
    {
       
        //Aqui estamos devolviendo el nombre del objeto desde el scriptableObject y lo mandamos a traer por su id desde el boton
        Debug.Log(objeto[id].GetComponent<ObjectType>().objectType);

        //aqui instanciamos el objeto que querramos construir
        Instantiate(objeto[id], CraftPos.position, CraftPos.rotation, null);
        
        piedra -= prefabItem.GetComponent<DraggableItem>().restarpiedra;
        roca -= prefabItem.GetComponent<DraggableItem>().restarroca;
        carbon -= prefabItem.GetComponent<DraggableItem>().restarcarbon;


        //objeto[id].transform.position = CraftPos.position;
        //player.GetComponent<InventoryManager>().AddItem(item);Objects item

    }





}
