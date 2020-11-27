using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }

    // enable control of player looking/moving
    public void EnablePlayerMovement()
    {
        Cursor.visible = false;
        FindObjectOfType<PlayerLook>().enabled = true;
        FindObjectOfType<PlayerMove>().enabled = true;

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
        FindObjectOfType<PlayerLook>().enabled = false;
        FindObjectOfType<PlayerMove>().enabled = false;

        // prevent player from clicking on NPCs for dialogue when 
        // player is already in dialogue
        var npcs = FindObjectsOfType<NPC>();
        foreach (NPC character in npcs)
        {
            character.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
