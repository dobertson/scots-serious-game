using UnityEngine;

/*
 *  This script handles the logic for when the player is on the main menu screen
 */
public class MenuMain : MonoBehaviour
{
    public bool isPlayerEntering;           // bool used to know if player should be moved into building
    public float enteringSpeed;             // speed at which to enter
    public Transform enteringPosition;      // position to move towards
    public GameObject mainMenuContainer;    // main menu UI contain
    public GameObject controlsContainer;       // UI showing player controls
    public GameObject mainMenuDoor;         // door that leads into building
    private GameObject player;

    public void Start()
    {
        mainMenuContainer.SetActive(true);
        controlsContainer.SetActive(false);
        player = GameObject.FindGameObjectWithTag(StringLiterals.PlayerTag);
        player.GetComponent<PlayerController>().DisablePlayerMovement();
        enteringPosition.position = new Vector3(
            enteringPosition.position.x,
            player.transform.position.y,    // set entering position to same height as player position to lock moving laong Y axis
            enteringPosition.position.z);
    }

    private void Update()
    {
        if (isPlayerEntering)
        {
            // move player inside building
            player.transform.position = Vector3.MoveTowards(
                player.transform.position,
                enteringPosition.position,
                enteringSpeed * Time.deltaTime);

            // if player is close to initial position
            if (Vector3.Distance(player.transform.position, enteringPosition.position) < 0.001f)
            {
                // stop moving player and enable player controller
                mainMenuDoor.SetActive(true);
                isPlayerEntering = false;
                FindObjectOfType<PlayerController>().EnablePlayerMovement();
            }
        }
    }

    // when player clicks Enter on main menu
    public void EnterBuilding()
    { 
        GameManager.gameState = GameState.FAIMLY;  // change state to first scene
        mainMenuContainer.SetActive(false);                 // disable main menu ui 
        mainMenuDoor.SetActive(false);                      // disable building door
        isPlayerEntering = true;                            // set bool so Update() can move player into building
        Cursor.lockState = CursorLockMode.Locked;           // hide cursor whilst moving into building
    }
}
