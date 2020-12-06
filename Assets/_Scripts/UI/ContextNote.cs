using UnityEngine;

public class ContextNote : MonoBehaviour
{
    [TextArea]
    public string noteText;
    public GameState showNoteOnState;
    private Outline outline;

    private ShowContextNote showContextNote;
    private InteractableDescription interactableDescription;

    private void Awake()
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
            showContextNote.ShowText(noteText);
            gameObject.SetActive(false);
            interactableDescription.Hide();
        }
    }

    private void OnMouseEnter()
    {
        outline.enabled = true;
    }

    private void OnMouseExit()
    {
        outline.enabled = false;
    }
}
