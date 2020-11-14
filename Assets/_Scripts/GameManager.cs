using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    MainMenu,
    EnteredBuilding,
    FinishedScene1,
    FinishedScene2,
    FinishedScene3,
    FinishedScene4,
    FinishedScene5,
    FinishedScene6
}

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    public float maxDistanceInteract;
    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        gameState = GameState.MainMenu;

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
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


