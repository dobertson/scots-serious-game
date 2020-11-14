using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NoteDelegate : MonoBehaviour
{
    public event Action<string> DisplayNote;
    public string noteText;

    private void OnMouseDown()
    {
        if (GameManager.Instance.IsPlayerCloseEnough(transform.position))
        {
            DisplayNote?.Invoke(noteText);
        }
    }
}
