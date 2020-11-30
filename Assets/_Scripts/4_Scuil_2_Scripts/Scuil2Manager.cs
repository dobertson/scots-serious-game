using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Scuil2Manager : MonoBehaviour
{
    private void Start()
    {
        //FindObjectOfType<DialogueRunner>().StartDialogue("Scuil2.Pal");
    }

    [YarnCommand("nextScene")]
    public void NextScene()
    {
        GameManager.Instance.gameState = GameState.JOAB;
        FindObjectOfType<SceneTransitionManager>().FadeToScene(StringLiterals.TenementScene);
    }
}
