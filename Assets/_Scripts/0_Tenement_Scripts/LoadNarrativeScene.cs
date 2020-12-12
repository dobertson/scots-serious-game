using System.Collections;
using UnityEngine;
/*
 * This script handles the moving from the main scene to each narrative scene.
 * Doors will only be available depending on what the game state is (ie. the current
 * progress the player is making through the narrative).
 */
public class LoadNarrativeScene : MonoBehaviour
{
    public string roomName;
    private string description;
    private bool isShowingDescription;

    public GameState openOnState;   //if game state to have this door open
    private string sceneName;

    private void Start()
    {
        isShowingDescription = false;

        switch (openOnState) 
        {
            // set scene name to load based on what state this door needs
            // for it to be open to player
            case (GameState.FAIMLY):
                sceneName = StringLiterals.FaimlyScene;
                break;
            case (GameState.SCUIL_1):
                sceneName = StringLiterals.Scuil1Scene;
                break;
            case (GameState.PALS):
                sceneName = StringLiterals.PalsScene;
                break;
            case (GameState.SCUIL_2):
                sceneName = StringLiterals.Scuil2Scene;
                break;
            case (GameState.JOAB):
                sceneName = StringLiterals.JoabScene;
                break;
            case (GameState.HAME):
                sceneName = StringLiterals.HameScene;
                break;
            default:
                sceneName = "";
                break;
        }

        // disable collider (and thus ability to enter door)
        // if player is not at this game state yet
        if (GameManager.Instance.gameState < openOnState)
        {
            GetComponent<Collider>().enabled = false;
        }

        if (GameManager.Instance.gameState == openOnState
            || (GameManager.Instance.gameState == GameState.MAIN_MENU && openOnState == GameState.FAIMLY))
        {
            description = $"Enter '{roomName}' memory?";
        }
        else
        {
            description = $"Revist '{roomName}' memory?";
        }

        // chaning from MAIN_MENU to FAIMLY state after this Start() runs
        // means that this door will not be accessible, so make it accisseble always
        if (openOnState == GameState.FAIMLY)
        {
            GetComponent<Collider>().enabled = true;
        }

        // hame is not a memory, so change wording
        if (openOnState == GameState.HAME)
        {
            description = "Go hame/home?";
        }

    }

    private void Update()
    {
        // similar to Interactable.cs in that it should hide the description if the plyaer moves
        // far away from the door but is still looking at it
        if (isShowingDescription)
        {
            if (!GameManager.IsPlayerCloseEnough(transform.position))
            {
                FindObjectOfType<InteractableDescription>().Hide();
                isShowingDescription = false;
            }
        }
    }

    // show description if looking at it
    private void OnMouseOver()
    {
        if (!isShowingDescription)
        {
            if (IsCloseEnough())
            {
                FindObjectOfType<InteractableDescription>().Show(description);
                isShowingDescription = true;
            }
            else
            {
                FindObjectOfType<InteractableDescription>().Hide();
                isShowingDescription = false;

            }
        }
    }

    // hide descripotion if not looking at the door
    private void OnMouseExit()
    {
        FindObjectOfType<InteractableDescription>().Hide();
        isShowingDescription = false;
    }

    // if player clicks on door, and is close enough, enter new scene
    private void OnMouseDown()
    {
        if (IsCloseEnough())
        {
            var soundManager = GameObject.FindGameObjectWithTag("SoundManager");
            soundManager.GetComponent<SoundManager>().PlayDoorOpeningSFX();
            FindObjectOfType<SceneTransitionManager>().FadeToScene(sceneName);
        }
    }

    // GameManager's IsPlayerCloseEnough is used everywhere in the game but here, since the landings between 
    // doors is short we don't want to show the next doors interactable descrition when players return 
    // to tenement scene
    private bool IsCloseEnough()
    {
        var minumDistance = 2f;
        var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        var distanceFromObject = Vector3.Distance(playerPosition, transform.position);

        // is custom distance has been specifiedm, use that distance instead
        if (distanceFromObject < minumDistance)
        {
            return true;
        }

        return false;
    }
}
