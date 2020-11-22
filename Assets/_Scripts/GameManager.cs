using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// state represented by which scene the player is currently experiencing
public enum GameState
{
    MAIN_MENU = 0,
    FAIMLY = 1,
    SCUIL = 2,
    SCENE_3 = 3,
    SCENE_4 = 4,
    SCENE_5 = 5,
    SCENE_6 = 6
}

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        // ensure there is only one game manager
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // quit application or stop playing if in unity editor
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }

    // given scene name, load that scene
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    // enable control of player looking/moving
    public void EnablePlayerMovement()
    {
        FindObjectOfType<PlayerLook>().enabled = true;
        FindObjectOfType<PlayerMove>().enabled = true;

        // enable colliders so player can start dialogues with other NPCs
        var npcs = FindObjectsOfType<NPC>();
        foreach (NPC character in npcs)
        {
            character.gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    // disable control of looking/moving
    public void DisablePlayerMovement()
    {
        FindObjectOfType<PlayerLook>().enabled = false;
        FindObjectOfType<PlayerMove>().enabled = false;

        // prevent player from clicking on NPCs for dialogue when 
        // player is already in dialogue
        var npcs = FindObjectsOfType<NPC>();
        foreach (NPC character in npcs)
        {
            character.gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    // used to determine if player is close enough to an object to
    // interact with it, talk to NPC or load new scene
    public bool IsPlayerCloseEnough(Vector3 objectPosition)
    {
        var minumDistance = 2f;
        var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        var distanceFromObject = Vector3.Distance(playerPosition, objectPosition);

        if (distanceFromObject < minumDistance)
        {
            return true;
        }

        return false;
    }
}


