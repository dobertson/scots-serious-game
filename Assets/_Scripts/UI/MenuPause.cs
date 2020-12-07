using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPause : MonoBehaviour
{
    public GameObject pauseMenuContainer;
    private bool isPaused;

    private PlayerController playerController;
    public GameObject contextNote;
    public GameObject fadeToBlack;
    public GameObject dialogue;
    public GameObject endingScene;

    private void Awake()
    {
        pauseMenuContainer.SetActive(false);
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (GameManager.gameState != GameState.MAIN_MENU 
            || SceneManager.GetActiveScene().name != StringLiterals.TenementScene)
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
        pauseMenuContainer.SetActive(true);
        playerController.DisablePlayerMovement();
    }

    public void HidePauseMenu()
    {
        // do not re-enable player movement if player paused
        // whilst other ui that disable players movement is open
        if (IsOtherUIShowing() == false)
        {
            playerController.EnablePlayerMovement();
        }
        isPaused = false;
        pauseMenuContainer.SetActive(false);
    }

    // if any of these interfaces are showing,
    // return true
    private bool IsOtherUIShowing()
    {
        return dialogue.activeSelf
            || contextNote.activeSelf
            || fadeToBlack.activeSelf
            || endingScene.activeSelf;
    }

}
