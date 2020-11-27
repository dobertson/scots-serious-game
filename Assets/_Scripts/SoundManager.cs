using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip doorOpeningSFX;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();    
    }

    public void PlayDoorOpeningSFX()
    {
        source.clip = doorOpeningSFX;
        source.Play();
    }
}
