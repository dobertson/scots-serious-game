using UnityEngine;
using Yarn.Unity;

/*
 * This script is attached to objects in the Faimly scene that can be picked up and 
 * brought to dad when he asks for his bunnet.
 */
public class DadItem : MonoBehaviour
{
    public string itemName; // item name

    private InMemoryVariableStorage dialgoueVariables;          // item name is stored here on pickup
    private InteractableDescription interactableDescription;    
    private SoundManager soundManager;
    private FaimlyManager faimlyManager;

    private void Awake()
    {
        tag = StringLiterals.DadItemTag; // set tag dynamically rather than for each item in inspector
        GetComponent<Collider>().enabled = false; // ensure player can't interact with item before dad give "find bunnet" quest

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
        // if player is close enough, and is not holding another item
        if (GameManager.IsPlayerCloseEnough(transform.position)
            && faimlyManager.canPickUpItem)
        {
            dialgoueVariables.SetValue("$held_item", itemName); // set the held item to check in the yarn script
            interactableDescription.Hide();                     // hide the "Pick up" item since we are about to disable this object
            gameObject.SetActive(false);
            soundManager.PlayItemPickupSFX();                   // play sfx
            faimlyManager.PreventDadItemPickup();               // prevent player from picking up other items
        }
    }
}
