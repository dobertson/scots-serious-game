using System.Collections.Generic;
using UnityEngine;

/*
 *  This class handles setting the players postion and facing
 *  direction based on whatever state the player entered the scene at
 */
public class PlayerStatePosition : MonoBehaviour
{
    public bool fromTheBeginning;                   // ignore what state is set in game manager and start from MAIN_MENU
    public List<Transform> playerStatePositions;    // list of positions of various states 

    private void Start()
    {
        SetupState();
    }

    void SetupState()
    {
        if (fromTheBeginning)
        {
            GameManager.Instance.gameState = GameState.MAIN_MENU;
        }

        // use state enum value as index to fetch position from playerStatePositions
        FindObjectOfType<PlayerMove>().transform.position = playerStatePositions[(int)GameManager.Instance.gameState].position;
        FindObjectOfType<PlayerMove>().transform.forward = playerStatePositions[(int)GameManager.Instance.gameState].forward;

        // since main menu object is on UI prefab (and set to disabled) need to enable it if in Main Menu scene
        if(GameManager.Instance.gameState == GameState.MAIN_MENU)
        {
            FindObjectOfType<MenuMain>().gameObject.SetActive(true);
        }
    }
}
