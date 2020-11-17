using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MAIN_MENU = -1,
    SCENE_0 = 0,
    SCENE_1 = 1,
    SCENE_2 = 2,
    SCENE_3 = 3,
    SCENE_4 = 4,
    SCENE_5 = 5
}

public class GameManager : MonoBehaviour
{
    public bool fromTheBeginning;
    public GameState gameState;
    public Transform mainMenuPosition;
    public List<Transform> playerStatePositions;
    public float maxDistanceInteract;
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        if (fromTheBeginning)
        {
            gameState = GameState.MAIN_MENU;
        }

        SetupState();
    }

    void SetupState()
    {
        Debug.Log($"Game State: {gameState}");
        if (gameState != GameState.MAIN_MENU)
        {
            FindObjectOfType<PlayerMove>().transform.position = playerStatePositions[(int)gameState].position;
            FindObjectOfType<PlayerMove>().transform.forward = playerStatePositions[(int)gameState].forward;

        }
        else
        {
            FindObjectOfType<PlayerMove>().transform.position = mainMenuPosition.position;
            FindObjectOfType<PlayerMove>().transform.forward = mainMenuPosition.forward;
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void EnablePlayerMovement()
    {
        FindObjectOfType<PlayerLook>().enabled = true;
        FindObjectOfType<PlayerMove>().enabled = true;


        var npcs = GameObject.FindGameObjectsWithTag("NPC");

        foreach (GameObject character in npcs)
        {
            character.GetComponent<Collider>().enabled = true;
        }
    }

    public void DisablePlayerMovement()
    {
        FindObjectOfType<PlayerLook>().enabled = false;
        FindObjectOfType<PlayerMove>().enabled = false;

        var npcs = GameObject.FindGameObjectsWithTag("NPC");

        foreach( GameObject character in npcs)
        {
            character.GetComponent<Collider>().enabled = false;
        }
    
    }

    public bool IsPlayerCloseEnough(Vector3 objectPosition)
    {
        var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        var distanceFromObject = Vector3.Distance(playerPosition, objectPosition);

        Debug.Log(distanceFromObject);

        if (distanceFromObject < maxDistanceInteract)
        {
            return true;
        }

        return false;
    }
}


