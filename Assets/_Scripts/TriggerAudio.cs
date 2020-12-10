using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * If player walks into collider, play sfx
 */

public class TriggerAudio : MonoBehaviour
{
    public bool playOnce; // prevent sfx playing more than once

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == StringLiterals.PlayerTag)
        {
            GetComponent<AudioSource>().Play();
            if (playOnce)
            {
                GetComponent<Collider>().enabled = false;
            }
        }
    }
}
