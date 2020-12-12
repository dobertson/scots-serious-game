using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 *  This class handles setting the players postion and facing
 *  direction based on whatever state the player entered the scene at
 */
public class SetupTenementScene : MonoBehaviour
{
    public List<Transform> playerStatePositions;    // list of positions of various states 
    public GameObject player;

    private void Start()
    {

        var player = GameObject.FindGameObjectWithTag(StringLiterals.PlayerTag);
        var playerCharController = player.GetComponent<CharacterController>();
        // character controller issue would reset player position, need to siable it before setting position
        // solution found from here https://forum.unity.com/threads/does-transform-position-work-on-a-charactercontroller.36149/#post-4132021
        playerCharController.enabled = false;
        player.transform.position = GetPosition();
        player.transform.forward = GetDirection();
        playerCharController.enabled = true;

        // red squares are used to see the player state positions in the editor,
        // make sure to disable the renderer if playing game
        foreach (Transform position in playerStatePositions)
        {
            position.gameObject.GetComponent<Renderer>().enabled = false;
        }        
    }

    // get the position for that state in the list using the enum value
    public Vector3 GetPosition()
    {
        return playerStatePositions[(int)GameManager.Instance.gameState].position;
    }

    // get the direction forward for that state in the list using the enum value
    public Vector3 GetDirection()
    {
        return playerStatePositions[(int)GameManager.Instance.gameState].forward;
    }
}
