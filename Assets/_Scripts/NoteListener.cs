using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteListener : MonoBehaviour
{
    NoteDelegate del;
    TextMeshProUGUI myText;

    public GameObject noteContainer;

    // Start is called before the first frame update
    void Awake()
    {
        del = FindObjectOfType<NoteDelegate>();
        noteContainer.SetActive(true);
        myText = GameObject.FindGameObjectWithTag("NoteText").GetComponent<TextMeshProUGUI>();
        noteContainer.SetActive(false);
    }

    private void OnEnable()
    {
        if(del)
        {
            del.DisplayNote += NoteTextChange;
        }
    }

    private void OnDisable()
    {
        if (del)
        {
            del.DisplayNote -= NoteTextChange;
        }
    }

    void NoteTextChange(string noteText)
    {
        GameManager.Instance.DisablePlayerMovement();
        noteContainer.SetActive(true);
        myText.text = noteText;
    }
}
