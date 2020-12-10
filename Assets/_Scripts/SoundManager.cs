using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this gameobject is common to all scenes,
 * has a list of commonly used sfx to play
 * at any given time
 */
public class SoundManager : MonoBehaviour
{
    private AudioSource source;
    public AudioClip doorOpeningSFX;
    public AudioClip pickUpItemSFX;
    public AudioClip notePickUpSFX;
    public AudioClip popSFX;
    public AudioClip ballKickSFX;
    public AudioClip phoneVibrationSFX;

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
        source.clip = pickUpItemSFX;
        source.Play();
    }

    public void PlayNotePickupSFX()
    {
        source.clip = notePickUpSFX;
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

    public void PlayPhoneVibration()
    {
        source.clip = phoneVibrationSFX;
        source.Play();
    }
}
