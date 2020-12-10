using UnityEngine;
using UnityEngine.EventSystems;

/*
 * This script is attached to context notes found on the stair well
 * in the tenement close scene
 */
public class ContextNote : MonoBehaviour
{
    [TextArea]
    public string noteText;
    public GameState showNoteOnState;
    private Outline outline;

    private ShowContextNote showContextNote;
    private InteractableDescription interactableDescription;

    private void Start()
    {
        // disable note if it should not show on this game state
        if(showNoteOnState != GameManager.Instance.gameState)
        {
            gameObject.SetActive(false);
        }

        //disable outline on start
        outline = GetComponent<Outline>();
        outline.enabled = false;

        showContextNote = FindObjectOfType<ShowContextNote>();
        interactableDescription = FindObjectOfType<InteractableDescription>();
    }

    private void OnMouseDown()
    {
        if (GameManager.IsPlayerCloseEnough(transform.position))
        {
            // fix from https://answers.unity.com/questions/1130888/onmousedown-work-through-ui-elements.html
            // when clicking the close button on UI, the click would go through a click the collider behind it,
            // this would mean both notes would open in one click if they are next to each other
            // this check fixes that
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                showContextNote.ShowText(noteText);
                gameObject.SetActive(false);
                interactableDescription.Hide();
            }
        }
    }

    private void OnMouseEnter()
    {
        // if player is close enough, show outline
        if (GameManager.IsPlayerCloseEnough(transform.position))
        {
            outline.enabled = true;
        }
    }

    // hide outline when mouse not over collider
    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
