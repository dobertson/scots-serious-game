using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PalsManager : MonoBehaviour
{
    [YarnCommand("nextScene")]
    public void NextScene()
    {
        GameManager.Instance.gameState = GameState.SCUIL_2;
        FindObjectOfType<SceneTransitionManager>().LoadScene(StringLiterals.TenementScene);
    }
}
