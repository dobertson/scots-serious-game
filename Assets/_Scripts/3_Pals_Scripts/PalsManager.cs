using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PalsManager : MonoBehaviour
{
    private SceneTransitionManager sceneTransitionManager;

    private void Awake()
    {
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
    }

    [YarnCommand("nextScene")]
    public void NextScene()
    {
        GameManager.gameState = GameState.SCUIL_2;
        sceneTransitionManager.FadeToScene(StringLiterals.TenementScene);
    }
}
