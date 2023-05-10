using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public enum tipoBarra
    {
        Vida, Hambre, Sed
    }
public class EstadisticasJugador : MonoBehaviour
{

    public tipoBarra tipoDeBarra;

    public Image barra;
    public Text valText;

    private float  valMax  = 100;

    public float ValActu = 100;

    //--Nuevoooo
    private EstadisticasJugador estadoHambre;
    private EstadisticasJugador estadoSed;

    void Awake()
    {

        estadoHambre = GameObject.Find("Hambre").GetComponent<EstadisticasJugador>();
        estadoSed = GameObject.Find("Sed").GetComponent<EstadisticasJugador>();

    }


    // Update is called once per frame
    void Update()
    {
        valText.text = tipoDeBarra + ": " + ValActu.ToString("f0");

        if(ValActu >= valMax)
        {
            ValActu = valMax;
        }

        if (ValActu == 0)
        {
            //Si la vida llega a cero ejecutaremos la animacion de morir
            Debug.Log("Moriste Pa");
        }

        if (ValActu <= 0)
        {
            ValActu = 0;
        }

        switch (tipoDeBarra)
        {
            case tipoBarra.Vida:
            //bajar vida cuando el hambre llega a 0
            if(estadoHambre.ValActu <= 0)
            {
                ValActu -= 1 * Time.deltaTime;
            }
            //bajar vida cuando el agua llega a 0
            if(estadoSed.ValActu <= 0)
            {
                ValActu -= 2 * Time.deltaTime;
            }
            //subir vida
            if(estadoHambre.ValActu >= 50)
            {
                //Sumar vida al player cuando la vida en nivel de hambre es mayor a 50 o podemos agregar que la vida suba cuando la barra de sed esta llena
                //ValActu += 1 * Time.deltaTime;
            }
                float vidaBarra = ValActu / valMax;
                IntroValActual(vidaBarra);
            break;


            case tipoBarra.Hambre:
            
                ValActu -= 0.1f * Time.deltaTime;
                float hambreBarra = ValActu / valMax;
                IntroValActual(hambreBarra);
            
            break;

            case tipoBarra.Sed: 
            //PERDER VIDA
                ValActu -= 0.09f *  Time.deltaTime;
                float manaBarra = ValActu / valMax;
                IntroValActual(manaBarra);
            break;
        }
    }

    void IntroValActual(float miBarra)
    {
        barra.fillAmount = miBarra;
    }
}
