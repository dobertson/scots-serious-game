using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DadItem : MonoBehaviour
{
    public string itemName;

    private InMemoryVariableStorage dialgoueVariables;
    private InteractableDescription interactableDescription;
    private SoundManager soundManager;
    private FaimlyManager faimlyManager;

    private void Awake()
    {
        tag = StringLiterals.DadItemTag;
        GetComponent<Collider>().enabled = false;

        dialgoueVariables = FindObjectOfType<InMemoryVariableStorage>();
        interactableDescription = FindObjectOfType<InteractableDescription>();
        soundManager = FindObjectOfType<SoundManager>();
        faimlyManager = FindObjectOfType<FaimlyManager>();
    }

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (GameManager.IsPlayerCloseEnough(transform.position)
            && faimlyManager.canPickUpItem)
        {
            dialgoueVariables.SetValue("$held_item", itemName);
            interactableDescription.Hide();
            gameObject.SetActive(false);
            soundManager.PlayItemPickupSFX();
            faimlyManager.PreventDadItemPickup();
        }
    }
}
