using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsWindow;
    public GameObject mainMenu;

    public void Awake()
    {
        mainMenu.SetActive(true);
        controlsWindow.SetActive(false);
        GameManager.Instance.DisablePlayerMovement();
    }

    public void EnterBuilding()
    {
        FindObjectOfType<MainMenuDoor>().OpenDoor();
        GameManager.Instance.gameState = GameState.EnteredBuilding;
        GameManager.Instance.EnablePlayerMovement();
        gameObject.SetActive(false);
    }
}
