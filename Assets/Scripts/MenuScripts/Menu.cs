using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Menu : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isGamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("PAUSE"))
        {
            
            isGamePaused = !isGamePaused;
            
            PauseGame();
        }

    }

    public void PauseGame()
    {
        if (isGamePaused)
        {
            
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
}
