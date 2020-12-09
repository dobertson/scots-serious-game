using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/*
 * This script handles the logic required for the Faimly scene
 */
public class FaimlyManager : MonoBehaviour
{
    public GameObject bunnetOnHead; // when player finds the bunnet, activate this
    public bool canPickUpItem;

    private InMemoryVariableStorage dialogueVariables;
    private SceneTransitionManager sceneTransitionManager;
    private GameObject[] dadItems;

    private void Awake()
    {
        bunnetOnHead.SetActive(false); //ensure it's inactive at start
        dialogueVariables = FindObjectOfType<InMemoryVariableStorage>();
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
    }

    private void Start()
    {
        // dad items have their tags set in an Awake function on another script
        // do this in Start to ensure it finds then after tag has been set
        dadItems = GameObject.FindGameObjectsWithTag(StringLiterals.DadItemTag);

        foreach (GameObject item in dadItems)
        {
            item.GetComponent<Collider>().enabled = false;
        }
    }

    // when dad asks you find his "bunnet", enable the collider
    // for each of the objecs so that user can pick them up 
    // to progress in the scene
    [YarnCommand("enableDadItems")]
    public void EnableDadItems()
    {
        canPickUpItem = true;

        foreach (GameObject item in dadItems)
        {
            item.GetComponent<Collider>().enabled = true;
        }
    }

    // set bunnet active so dad wears it when you find it
    [YarnCommand("wearBunnet")]
    public void WearBunnet()
    {
        bunnetOnHead.SetActive(true);
    }

    // reset held item
    [YarnCommand("clearHeldItem")]
    public void ClearHeldItem()
    {
        dialogueVariables.SetValue("$held_item", "");
        ResetDadItems();
        canPickUpItem = true;
    }

    // end of dialogue,
    // change state and return to tenement scene
    [YarnCommand("endScene")]
    public void EndScene()
    {
        GameManager.Instance.gameState = GameState.SCUIL_1;
        sceneTransitionManager.FadeToScene(StringLiterals.TenementScene);
    }

    public void ResetDadItems()
    {
        // reset the pickup 
        foreach (GameObject item in dadItems)
        {
            item.GetComponent<Interactable>().description = "Pick up";
            item.GetComponent<DadItem>().enabled = true;
        }
    }

    public void PreventDadItemPickup()
    {
        canPickUpItem = false;
        // reset the pickup 
        foreach (GameObject item in dadItems)
        {
            item.GetComponent<Interactable>().description = "Ye cannae haud mair than wan hing";
        }
    }
}
