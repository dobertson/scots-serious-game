using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowContextNote : MonoBehaviour
{
    TextMeshProUGUI myText;

    public GameObject noteContainer;

    // Start is called before the first frame update
    void Awake()
    {
        noteContainer.SetActive(true);
        myText = GameObject.FindGameObjectWithTag("NoteText").GetComponent<TextMeshProUGUI>();
        noteContainer.SetActive(false);
    }

    public void ShowText(string noteText)
    {
        FindObjectOfType<PlayerController>().DisablePlayerMovement();
        noteContainer.SetActive(true);
        myText.text = noteText;
    }
}
