using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour
{
    public ThirdPersonOrbitCamBasic cameraScript;
    public MoveBehaviour movimientoPlayer;
    public GameObject camaraCrafteo;
    public GameObject player;
    public GameObject Selected;
    //public GameObject MiniMap;
    public GameObject TextDetect;
    public GameObject pool;
    public GameObject textInv;

    public GameObject Crafteo;

    public GameObject interfaceController;
    void Update() 
     {
        //DesactivarObjeto();
     }

    public void ActivarObjeto()
    {
        interfaceController.GetComponent<InterfaceController>().InvActive=true;
        textInv.SetActive(false);
        Crafteo.SetActive(true);
        pool.SetActive(false);
        Selected.GetComponent<Selected>().Deselect();
        TextDetect.SetActive(false);
        //MiniMap.SetActive(false);
        //cameraScript.enabled = false;
        movimientoPlayer.enabled = false;
        camaraCrafteo.SetActive(true);
        player.SetActive(false);
        Cursor.lockState = CursorLockMode.None;

    }

    public void DesactivarObjeto()
    {
            interfaceController.GetComponent<InterfaceController>().InvActive=false;
            Crafteo.SetActive(false);
            pool.SetActive(true);
            textInv.SetActive(true);

            //MiniMap.SetActive(true);
            //cameraScript.enabled = true;
            movimientoPlayer.enabled = true;
            camaraCrafteo.SetActive(false);
            player.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
    }

    



}
