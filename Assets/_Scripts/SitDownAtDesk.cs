using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SitDownAtDesk : MonoBehaviour
{
    public Transform sittingPosition;

    private void OnMouseDown()
    {
        if (GameManager.Instance.IsPlayerCloseEnough(transform.position))
        {
            GameManager.Instance.DisablePlayerMovement();
            var player = FindObjectOfType<PlayerMove>();
            player.transform.position = sittingPosition.position;
            player.transform.forward = sittingPosition.forward;
            player.transform.eulerAngles = sittingPosition.eulerAngles;
            FindObjectOfType<PlayerLook>().transform.rotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Collider>().enabled = false;
            FindObjectOfType<DialogueRunner>().StartDialogue("Teacher.Welcome");
        }
    }
}
