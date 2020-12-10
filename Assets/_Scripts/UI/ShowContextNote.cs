using TMPro;
using UnityEngine;

/*
 * Script that sets the text and shows the context note UI
 */
public class ShowContextNote : MonoBehaviour
{
    private TextMeshProUGUI myText;
    private AudioSource source;
    public GameObject noteContainer;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Awake()
    {
        noteContainer.SetActive(true);
        myText = GameObject.FindGameObjectWithTag("NoteText").GetComponent<TextMeshProUGUI>();
        noteContainer.SetActive(false);
        source = GetComponent<AudioSource>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // show the context ui with the given text
    public void ShowText(string noteText)
    {
        playerController.DisablePlayerMovement();
        noteContainer.SetActive(true);
        myText.text = noteText;
        source.pitch = 1f; // play a book opening sfx
        source.Play();
    }
}
