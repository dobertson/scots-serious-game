using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsWindow;
    public GameObject mainMenu;

    public void Start()
    {
        if(GameManager.Instance.gameState == GameState.MAIN_MENU)
        {
            mainMenu.SetActive(true);
            GameManager.Instance.DisablePlayerMovement();
        }
        else
        {
            mainMenu.SetActive(false);
            GameManager.Instance.EnablePlayerMovement();
        }

        controlsWindow.SetActive(false);
    }

    public void EnterBuilding()
    {
        // open door and enter building
        //FindObjectOfType<MainMenuDoor>().OpenDoor();
        GameManager.Instance.gameState = GameState.SCENE_0;
        GameManager.Instance.EnablePlayerMovement();
        gameObject.SetActive(false);
    }
}
