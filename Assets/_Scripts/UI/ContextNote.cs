using UnityEngine;

public class ContextNote : MonoBehaviour
{
    [TextArea]
    public string noteText;
    public GameState showNoteOnState;

    private void Start()
    {
        if(showNoteOnState != GameManager.Instance.gameState)
        {
            gameObject.SetActive(false);
        }
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
}
