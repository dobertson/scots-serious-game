using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowContextNote : MonoBehaviour
{
    TextMeshProUGUI myText;
    private AudioSource source;
    public GameObject noteContainer;

    // Start is called before the first frame update
    void Awake()
    {
        noteContainer.SetActive(true);
        myText = GameObject.FindGameObjectWithTag("NoteText").GetComponent<TextMeshProUGUI>();
        noteContainer.SetActive(false);
        source = GetComponent<AudioSource>();
    }

    public void ShowText(string noteText)
    {
        FindObjectOfType<PlayerController>().DisablePlayerMovement();
        noteContainer.SetActive(true);
        myText.text = noteText;
        source.pitch = 1f;
        source.Play();
    }
}
