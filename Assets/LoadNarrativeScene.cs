using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Darren;

public class LoadNarrativeScene : MonoBehaviour
{
    public string sceneName;

    // if player clicks on door, and is close enough, enter new scene
    private void OnMouseDown()
    {
        var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        var distanceFromDoor = Vector3.Distance(playerPosition, transform.position);

        if (distanceFromDoor < 0.3f)
        {
            // INSERT "DO YOU WANT TO ENTER SCENENAME" CODE HERE
            GameManager.Instance.LoadScene(sceneName);
        }
    }
}
