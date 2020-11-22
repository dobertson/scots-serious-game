using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject pauseMenuContainer;
    private bool isPaused;

    private void Awake()
    {
        pauseMenuContainer.SetActive(false);
    }

    private void Update()
    {
        if (GameManager.Instance.gameState != GameState.MAIN_MENU || SceneManager.GetActiveScene().name != "0_TenementClose")
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameManager.Instance.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void ShowPauseMenu()
    {
        isPaused = true;
        pauseMenuContainer.SetActive(true);
        GameManager.Instance.DisablePlayerMovement();
    }

    public void HidePauseMenu()
    {
        isPaused = false;
        pauseMenuContainer.SetActive(false);
        GameManager.Instance.EnablePlayerMovement();
    }
}
