using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public string description;
    private bool isShowingDescription;

    private void Awake()
    {
        isShowingDescription = false;
    }

    private void Update()
    {
        if (isShowingDescription)
        {
            if (!GameManager.IsPlayerCloseEnough(transform.position))
            {
                FindObjectOfType<InteractableDescription>().Hide();
                isShowingDescription = false;
            }
        }
    }

    private void OnMouseOver()
    {
        if (!isShowingDescription)
        {
            if (GameManager.IsPlayerCloseEnough(transform.position))
            {
                FindObjectOfType<InteractableDescription>().Show(description);
                isShowingDescription = true;
            }
        }
    }

    private void OnMouseExit()
    {
        FindObjectOfType<InteractableDescription>().Hide();
        isShowingDescription = false;
    }
}
