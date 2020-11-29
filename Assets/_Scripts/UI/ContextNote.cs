using UnityEngine;

public class ContextNote : MonoBehaviour
{
    [TextArea]
    public string noteText;
    public GameState showNoteOnState;
    private Outline outline;

    private void Start()
    {
        if(showNoteOnState != GameManager.Instance.gameState)
        {
            gameObject.SetActive(false);
        }

        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.IsPlayerCloseEnough(transform.position))
        {
            FindObjectOfType<ShowContextNote>().ShowText(noteText);
            gameObject.SetActive(false);
            FindObjectOfType<InteractableDescription>().Hide();
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
