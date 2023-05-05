using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsPlayer : MonoBehaviour
{

    public GameObject ActivarGuia;
    public GameObject ActivarPlayer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ActivarObjeto();
        DesactivarObjeto();
    }


    public void ActivarObjeto()
    {
        if (Input.GetButton("Y"))
        {
            ActivarGuia.SetActive(true);
            ActivarPlayer.SetActive(false);
        }
    }

    public void DesactivarObjeto()
    {
        if (Input.GetButton("B"))
        {
            ActivarGuia.SetActive(false);
            ActivarPlayer.SetActive(true);
        }
    }

}
