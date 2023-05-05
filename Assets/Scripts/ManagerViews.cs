using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManagerViews : MonoBehaviour
{

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
        SceneManager.LoadScene(2);
    }

    public void CargarJuego()
    {
        //SceneManager.LoadScene(2);
        Debug.Log("Se Cargara La Partida Que El Player Guardo Por Ultima Vez");
    }
    public void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Se ha salido del juego");
    }
}
