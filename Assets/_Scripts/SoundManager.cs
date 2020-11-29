using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip doorOpeningSFX;
    public AudioClip pickUpSFX;
    public AudioClip popSFX;
    public AudioClip ballKickSFX;

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

    public void PlayItemPickupSFX()
    {
        source.clip = pickUpSFX;
        source.Play();
    }

    public void PlayPopSFX()
    {
        source.clip = popSFX;
        source.Play();
    }

    public void PlayBallKickSFX()
    {
        source.clip = ballKickSFX;
        source.Play();
    }
}
