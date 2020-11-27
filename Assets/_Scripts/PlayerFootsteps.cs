using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    public AudioSource footstepSource;
    private Vector3 lastStep;
    public float minimumStepDistance;

    private void Start()
    {
        lastStep = transform.position;
    }

    private void Update()
    {
        var distanceFromLastStep = Vector3.Distance(lastStep, transform.position);

        if(distanceFromLastStep > minimumStepDistance)
        {
            footstepSource.pitch = Random.Range(0.8f, 1f);
            footstepSource.Play();
            lastStep = transform.position;
        }
    }


}
