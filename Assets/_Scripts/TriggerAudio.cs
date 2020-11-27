using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public bool playOnce;

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
