using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
    

        void Update()
        {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameManager.Instance.DisablePlayerMovement();
            var player = FindObjectOfType<PlayerMove>();
            player.transform.position = sittingPosition.position;
            player.transform.forward = sittingPosition.forward;
            player.transform.eulerAngles = sittingPosition.eulerAngles;
            FindObjectOfType<PlayerLook>().transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        }
}
