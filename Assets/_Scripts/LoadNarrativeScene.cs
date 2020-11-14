using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNarrativeScene : MonoBehaviour
{
    public string sceneName;

    // if player clicks on door, and is close enough, enter new scene
    private void OnMouseDown()
    {
        if (GameManager.Instance.IsPlayerCloseEnough(transform.position))
        {
            // INSERT "DO YOU WANT TO ENTER SCENENAME" CODE HERE
            GameManager.Instance.LoadScene(sceneName);
        }
    }
}
