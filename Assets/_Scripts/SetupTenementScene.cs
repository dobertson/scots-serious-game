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
    public GameObject hame;

    private void Awake()
    {
        if(GameManager.Instance.gameState == GameState.HAME)
        {
            hame.SetActive(true);
        }
        else
        {
            hame.SetActive(false);
        }

        foreach (Transform position in playerStatePositions)
        {
            position.gameObject.GetComponent<Renderer>().enabled = false;
        }

        var player = GameObject.FindGameObjectWithTag(StringLiterals.PlayerTag);
        var playerCharController = player.GetComponent<CharacterController>();
        //character controller issue would reset player position, fixed here https://forum.unity.com/threads/does-transform-position-work-on-a-charactercontroller.36149/#post-4132021
        playerCharController.enabled = false;
        player.transform.position = GetPosition();
        player.transform.forward = GetDirection();
        playerCharController.enabled = true;
    }

    public Vector3 GetPosition()
    {
        return playerStatePositions[(int)GameManager.Instance.gameState].position;
    }
    public Vector3 GetDirection()
    {
        return playerStatePositions[(int)GameManager.Instance.gameState].forward;
    }
}
