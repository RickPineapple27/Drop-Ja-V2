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


}
