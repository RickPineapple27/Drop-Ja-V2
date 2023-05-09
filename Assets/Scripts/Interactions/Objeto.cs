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
    public GameObject MiniMap;
    public GameObject TextDetect;
    public GameObject inventory;



    public void Start()
    {
    }
     void Update() 
     {
        DesactivarObjeto();
     }

    public void ActivarObjeto()
    {
        inventory.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        inventory.SetActive(false);
        Selected.GetComponent<Selected>().Deselect();
        TextDetect.SetActive(false);
        MiniMap.SetActive(false);
        //cameraMovement.GetComponent<Selected>().MesaCrafteo();
        cameraScript.enabled = false;
        movimientoPlayer.enabled = false;
        camaraCrafteo.SetActive(true);
        player.SetActive(false);
        //Destroy(gameObject);
        //Debug.Log("Abrimos mesa de creacion");
       
    }

        public void DesactivarObjeto()
    {

        if (Input.GetButtonDown("B"))
        {

        inventory.SetActive(true);
        MiniMap.SetActive(true);
        cameraScript.enabled = true;
        movimientoPlayer.enabled = true;
        camaraCrafteo.SetActive(false);
        player.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;


            //Debug.Log("Cerramos mesa de creacion");

        }

    }



}
