using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPoem : MonoBehaviour
{
    public GameObject closeUpPoem;

    private SoundManager soundManager;
    private InteractableDescription interactableDescription;

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
        interactableDescription = FindObjectOfType<InteractableDescription>();
    }

    private void Start()
    {
        closeUpPoem.SetActive(false);
    }

    private void OnMouseDown()
    {
        soundManager.PlayNotePickupSFX();
        interactableDescription.Hide();
        closeUpPoem.SetActive(true);
    }
}
