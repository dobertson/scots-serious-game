using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class DadItem : MonoBehaviour
{
    public string itemName;

    private void Awake()
    {
        tag = StringLiterals.DadItemTag;
        GetComponent<Collider>().enabled = false;
    }

    private void OnMouseDown()
    {
        if (GameManager.Instance.IsPlayerCloseEnough(transform.position))
        {
            FindObjectOfType<InMemoryVariableStorage>().SetValue("$held_item", itemName);
            FindObjectOfType<InteractableDescription>().Hide();
            gameObject.SetActive(false);
        }
    }
}
