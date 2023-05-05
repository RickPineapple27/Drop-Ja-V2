using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeEscena : MonoBehaviour
{
    public Transform puntoInicial;
    public Transform puntoEntrada;

    public GameObject personaje;

    public CambioDeEscena cambioEscena;
    void Awake()
    {
        personaje = GameObject.FindGameObjectWithTag("Player");
        puntoInicial = GameObject.FindGameObjectWithTag("PuntoInicial").transform;
        puntoEntrada = GameObject.FindGameObjectWithTag("PuntoEntrada").transform;
       

    }

    void Start()
    {
        //cambioEscena.enabled = false;
        //MoverAPuntoIncial();
    }

    public void Update()
    {

    }

    public void MoverAPuntoIncial()
    {
        personaje.transform.position = puntoInicial.position;
    }

    public void MoverAPuntoEntrada()
    {
        personaje.transform.position = puntoEntrada.position;
    }






}
