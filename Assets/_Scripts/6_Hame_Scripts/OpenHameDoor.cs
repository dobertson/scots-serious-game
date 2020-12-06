using System.Collections;
using UnityEngine;

/*
 *  This code handles opening the door to home, the final scene
 */
public class OpenHameDoor : MonoBehaviour
{
    private InteractableDescription interactableDescription;
    private SoundManager soundManager;

    private void Awake()
    {
        // interactable only if on final game state
        if(GameManager.Instance.gameState != GameState.HAME)
        {
            GetComponent<Collider>().enabled = false;
        }

        interactableDescription = FindObjectOfType<InteractableDescription>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    // if player is close, play door sfx, wait for it to finish, then disable the door
    private void OnMouseDown()
    {
        if (GameManager.IsPlayerCloseEnough(transform.position))
        {
            soundManager.PlayDoorOpeningSFX();
            StartCoroutine(WaitForSound(soundManager.GetComponent<AudioSource>()));
        }
    }

    // wait until sound has finished playing before opening door
    public IEnumerator WaitForSound(AudioSource audiosource)
    {
        yield return new WaitUntil(() => audiosource.isPlaying == false);
        interactableDescription.Hide(); // ensure this is hidden after disabling door
        gameObject.SetActive(false);
    }
}
