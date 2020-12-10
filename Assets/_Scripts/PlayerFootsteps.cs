using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is attached to the player and will play footstep sfx
 */
public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepSource;      // the sfx
    private Vector3 lastStep;               // keep record of last position of step
    public float minimumStepDistance;       // min distance between steps to play sound

    private void Start()
    {
        lastStep = transform.position; // store the initial step position
    }

    private void Update()
    {

        // if distance between steps is enough, play sfx
        var distanceFromLastStep = Vector3.Distance(lastStep, transform.position);

        if(distanceFromLastStep > minimumStepDistance)
        {
            footstepSource.pitch = Random.Range(0.8f, 1f);
            footstepSource.Play();
            lastStep = transform.position;
        }
    }


}
