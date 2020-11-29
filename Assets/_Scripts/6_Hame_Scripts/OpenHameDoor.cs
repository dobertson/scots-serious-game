using System.Collections;
using UnityEngine;

/*
 *  This code handles opening the door to home, the final scene
 */
public class OpenHameDoor : MonoBehaviour
{
    private void Start()
    {
        // interactable only if on final game state
        if(GameManager.Instance.gameState != GameState.HAME)
        {
            GetComponent<Collider>().enabled = false;
        }
    }

    // if player is close, play door sfx, wait for it to finish, then disable the door
    private void OnMouseDown()
    {
        if (GameManager.Instance.IsPlayerCloseEnough(transform.position))
        {
            var soundManager = GameObject.FindGameObjectWithTag("SoundManager");
            soundManager.GetComponent<SoundManager>().PlayDoorOpeningSFX();
            StartCoroutine(WaitForSound(soundManager.GetComponent<SoundManager>().GetComponent<AudioSource>()));
        }
    }

    // wait until sound has finished playing before opening door
    public IEnumerator WaitForSound(AudioSource audiosource)
    {
        yield return new WaitUntil(() => audiosource.isPlaying == false);
        FindObjectOfType<InteractableDescription>().Hide(); // ensure this is hidden after disabling door
        gameObject.SetActive(false);
    }
}
