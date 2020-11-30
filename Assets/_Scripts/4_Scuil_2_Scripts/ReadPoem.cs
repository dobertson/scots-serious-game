using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPoem : MonoBehaviour
{
    public GameObject closeUpPoem;

    private void Start()
    {
        closeUpPoem.SetActive(false);
    }

    private void OnMouseDown()
    {
        FindObjectOfType<SoundManager>().PlayNotePickupSFX();
        FindObjectOfType<InteractableDescription>().Hide();
        closeUpPoem.SetActive(true);
    }
}
