using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject controlsWindow;

    public void Awake()
    {
        controlsWindow.SetActive(false);
        FindObjectOfType<PlayerLook>().enabled = false;
        FindObjectOfType<PlayerMove>().enabled = false;
    }

    public void EnterBuilding()
    {
        FindObjectOfType<MainMenuDoor>().OpenDoor();
        FindObjectOfType<PlayerLook>().enabled = true;
        FindObjectOfType<PlayerMove>().enabled = true;
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
