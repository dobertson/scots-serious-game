using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenHameDoor : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameManager.Instance.IsPlayerCloseEnough(transform.position))
        {
            var soundManager = GameObject.FindGameObjectWithTag("SoundManager");
            soundManager.GetComponent<SoundManager>().PlayDoorOpeningSFX();
            StartCoroutine(WaitForSound(soundManager.GetComponent<SoundManager>().GetComponent<AudioSource>()));
        }
    }

    public IEnumerator WaitForSound(AudioSource audiosource)
    {
        yield return new WaitUntil(() => audiosource.isPlaying == false);
        FindObjectOfType<InteractableDescription>().Hide();
        gameObject.SetActive(false);
    }
}
