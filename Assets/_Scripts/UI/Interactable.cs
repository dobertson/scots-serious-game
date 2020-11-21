﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public string description;
    public bool isShowingDescription;

    private void Awake()
    {
        isShowingDescription = false;
    }

    private void Update()
    {
        if (isShowingDescription)
        { 
            if (!GameManager.Instance.IsPlayerCloseEnough(transform.position))
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
            if (GameManager.Instance.IsPlayerCloseEnough(transform.position))
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
