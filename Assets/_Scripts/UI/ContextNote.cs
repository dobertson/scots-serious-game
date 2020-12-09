using UnityEngine;
using UnityEngine.EventSystems;

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
        if(showNoteOnState != GameManager.Instance.gameState)
        {
            gameObject.SetActive(false);
        }

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
        if (GameManager.IsPlayerCloseEnough(transform.position))
        {
            outline.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
