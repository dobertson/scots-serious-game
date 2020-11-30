using UnityEngine;
using Yarn.Unity;

/*
 *  Sit playe down for a conversation by you provide a sitting position, 
 *  a look at position and the dialogue node to start at.
 */
public class SitDownStartDialogue : MonoBehaviour
{
    public Transform sittingPosition;   // position to put player
    public Transform lookAtPosition;    // position to look at when seated
    public string startYarnNode;        // dialogue node to start seated
    public bool setPositionsInPlayMode; // used when tweaking the positions in play mode
    private PlayerMove playerMove;
    private PlayerLook playerLook;

    private void Start()
    {
        setPositionsInPlayMode = false; //ensure this is always false, and can only be set true in inspector
        playerMove = FindObjectOfType<PlayerMove>();
        playerLook = FindObjectOfType<PlayerLook>();
    }

    void OnMouseDown()
    {
        // if player is close enough to sit
        if (GameManager.Instance.IsPlayerCloseEnough(transform.position))
        {
            FindObjectOfType<PlayerController>().DisablePlayerMovement();       // disable movement
            playerMove.transform.position = sittingPosition.position;           // set positions
            playerLook.transform.LookAt(lookAtPosition);
            GetComponent<Collider>().enabled = false;                           // ensure you can't click and execute this code again
            FindObjectOfType<DialogueRunner>().StartDialogue(startYarnNode);    // start dialogue
        }
    }

    private void Update()
    {
        // enable this bool in runtime when i want to tweak any 
        // positions and see changes happen in realtime
        if (setPositionsInPlayMode)
        {
            playerMove.transform.position = sittingPosition.position;
            playerLook.transform.LookAt(lookAtPosition);
        }
    }
}
