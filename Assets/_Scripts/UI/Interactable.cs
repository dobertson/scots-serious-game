using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 *  This script is attached to object that are interactable with a left click.
 *  It will display a description on the canvas when looking at an object,
 *  eg. "Pick up item" or "Open door"
 */
public class Interactable : MonoBehaviour
{
    public string description;          // text to show
    private bool isShowingDescription;  // bool to keep track is description is showing

    private InteractableDescription interactableDescription;

    private void Awake()
    {
        isShowingDescription = false;
        interactableDescription = FindObjectOfType<InteractableDescription>();
    }

    private void Update()
    {
        // this checks if the player is looking at the object, but is moving far enough away that 
        // they can no longer actually click on it in order to hide it
        if (isShowingDescription)
        {
            if (!GameManager.IsPlayerCloseEnough(transform.position))
            {
                interactableDescription.Hide();
                isShowingDescription = false;
            }
        }
    }

    // if looking at interactable object and player is close enough, show description
    private void OnMouseOver()
    {
        if (!isShowingDescription)
        {
            if (GameManager.IsPlayerCloseEnough(transform.position))
            {
                interactableDescription.Show(description);
                isShowingDescription = true;
            }
        }
    }

    // if not looking, hide description
    private void OnMouseExit()
    {
        interactableDescription.Hide();
        isShowingDescription = false;
    }
}
