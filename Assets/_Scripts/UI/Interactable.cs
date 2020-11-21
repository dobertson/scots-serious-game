using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public string description;
    public bool isShowingDescription;

    private void Update()
    {
        if (isShowingDescription)
        {
            var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            var distanceFromObject = Vector3.Distance(playerPosition, transform.position);

            if (distanceFromObject > 5f)
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
            if (IsPlayerCloseEnough())
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

    private bool IsPlayerCloseEnough()
    {
        var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        var distanceFromObject = Vector3.Distance(playerPosition, transform.position);

        if (distanceFromObject < 5f)
        {
            return true;
        }

        return false;
    }
}
