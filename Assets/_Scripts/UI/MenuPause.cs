using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This class handles the pausing of the game
 */
public class MenuPause : MonoBehaviour
{
    public GameObject pauseMenuContainer;           // pause menu gameobject in the canvas
    private bool isPaused;                          // keep track if the menu is open

    private PlayerController playerController;
    public GameObject contextNote;  // these objects are used to see if other ui is open whilst the player pauses
    public GameObject fadeToBlack;  // so we can know whether to enable the player movement or not
    public GameObject dialogue;
    public GameObject endingScene;

    private void Awake()
    {
        pauseMenuContainer.SetActive(false);
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        // don't let player pause in the main menu screen
        if (GameManager.Instance.gameState != GameState.MAIN_MENU 
            || SceneManager.GetActiveScene().name != StringLiterals.TenementScene)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // if they press the escape key again, hide the pause menu
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

    // show pause menu, disable player movement
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
