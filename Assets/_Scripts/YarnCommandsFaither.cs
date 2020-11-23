using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class YarnCommandsFaither : MonoBehaviour
{
    public GameObject bunnetOnHead;

    private void Start()
    {
        bunnetOnHead.SetActive(false);
    }

    // when dad asks you find his "bunnet", enable the collider
    // for each of the objecs so that user can pick them up 
    // to progress in the story
    [YarnCommand("enableDadItems")]
    public void EnableDadItems()
    {
        var items = GameObject.FindGameObjectsWithTag(StringLiterals.DadItemTag);

        foreach (GameObject item in items)
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
        FindObjectOfType<InMemoryVariableStorage>().SetValue("$held_item", "");
    }

    [YarnCommand("endScene")]
    public void EndScene()
    {
        GameManager.Instance.gameState = GameState.SCUIL;
        GameManager.Instance.LoadScene("02_Scuil");
    }
}
