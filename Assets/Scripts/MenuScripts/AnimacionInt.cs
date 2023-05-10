using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimacionInt : MonoBehaviour
{
    public Animator Animator_settings;
    public Animator Animator_Credits;
    public Animator Animator_Instructions;

    public void MostrarSettings()
    {
        Animator_settings.SetBool("Open",true);
        Animator_Credits.SetBool("Open", false);
        Animator_Instructions.SetBool("Open", false);
        //Animator_settings.SetTrigger("close");
    }

        public void MostrarCredits()
    {
        Animator_Credits.SetBool("Open", true);
        Animator_Instructions.SetBool("Open", false);
        Animator_settings.SetBool("Open",false);
    }

    public void MostrarInstructions()
    {
        Animator_Instructions.SetBool("Open", true);
        Animator_Credits.SetBool("Open", false);
        Animator_settings.SetBool("Open",false);
    }

        public void OcultarPanel()
    {
          if(Input.GetButton("B"))
        {
        Animator_Instructions.SetBool("Open", false);
        Animator_Credits.SetBool("Open", false);
        Animator_settings.SetBool("Open",false);
        }

    }

    public void Update() 
    {
        OcultarPanel();
    }



    public void InicioGame()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Inicio", LoadSceneMode.Single);
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Single);
    }
        public void Loading1()
    {
        SceneManager.LoadScene("Loading1", LoadSceneMode.Single);
    }

    public void CargarJuego()
    {
        Application.Quit();
        Debug.Log("Se Cargara La Partida Que El Player Guardo Por Ultima Vez");
    }
    public void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Se ha salido del juego");
    }
}
