using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * This script handles enabling/disabling the scripts
 * that handle player movement and looking
 */
public class PlayerController : MonoBehaviour
{
    private PlayerLook playerLook;
    private PlayerMove playerMove;
    void Start()
    {
        // hide cursor when moving
        Cursor.visible = false;
        playerLook = FindObjectOfType<PlayerLook>();
        playerMove = FindObjectOfType<PlayerMove>();
    }

    // enable control of player looking/moving
    public void EnablePlayerMovement()
    {
        Cursor.visible = false;
        playerLook.enabled = true;
        playerMove.enabled = true;

        // enable colliders so player can start dialogues with other NPCs
        var npcs = FindObjectsOfType<NPC>();
        foreach (NPC character in npcs)
        {
            character.gameObject.GetComponent<Collider>().enabled = true;
        }
    }

    // disable control of looking/moving
    public void DisablePlayerMovement()
    {
        Cursor.visible = true;
        playerLook.enabled = false;
        playerMove.enabled = false;

        // prevent player from clicking on NPCs for dialogue when 
        // player is already in dialogue
        var npcs = FindObjectsOfType<NPC>();
        foreach (NPC character in npcs)
        {
            character.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
