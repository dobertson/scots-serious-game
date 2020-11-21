using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused;

    private void Awake()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.gameState != GameState.MAIN_MENU)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(isPaused)
                {
                    HidePauseMenu();
                }
                else 
                {
                    ShowPauseMenu();
                }
                
            }
        }       
    }

    public void ShowPauseMenu()
    {
        isPaused = true;
        pauseMenu.SetActive(true);
        GameManager.Instance.DisablePlayerMovement();
    }

    public void HidePauseMenu()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        GameManager.Instance.EnablePlayerMovement();
    }
}
