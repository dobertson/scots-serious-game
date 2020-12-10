using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  When teacher has finished speaking, let player pick up poem
 */
public class ReadPoem : MonoBehaviour
{
    public GameObject closeUpPoem;  // poem that is disabled that when enabled shows poem close to player camera

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

    // pick up and show poem
    private void OnMouseDown()
    {
        soundManager.PlayNotePickupSFX();
        interactableDescription.Hide();
        closeUpPoem.SetActive(true);
    }
}
