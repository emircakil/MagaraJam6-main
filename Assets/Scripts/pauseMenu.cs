using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class pauseMenu : MonoBehaviour
{

    public GameObject PausePanel;

    void Update()
    {

        if (Keyboard.current.pKey.IsPressed())
        {

            Pause();
        }
        
    }

    

    public void Pause() 
    { 
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Continue() {

        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {

        Application.Quit();
    }
}
