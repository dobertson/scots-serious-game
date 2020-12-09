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

    }

    private void Update()
    {
        if (isShowingDescription)
        {
            if (!GameManager.IsPlayerCloseEnough(transform.position))
            {
                FindObjectOfType<InteractableDescription>().Hide();
                isShowingDescription = false;
            }
        }
    }

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
