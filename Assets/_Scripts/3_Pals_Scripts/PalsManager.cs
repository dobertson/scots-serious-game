using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/*
 * This script handles the logic for the pals scene
 */
public class PalsManager : MonoBehaviour
{
    private SceneTransitionManager sceneTransitionManager;

    private void Awake()
    {
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
    }

    // when dialogue is finished, fade to black
    [YarnCommand("nextScene")]
    public void NextScene()
    {
        GameManager.Instance.gameState = GameState.SCUIL_2;
        sceneTransitionManager.FadeToScene(StringLiterals.TenementScene);
    }
}
