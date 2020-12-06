using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class JoabManager : MonoBehaviour
{
    private SceneTransitionManager sceneTransitionManager;
    private DialogueRunner dialogueRunner;
    private SoundManager soundManager;

    private void Awake()
    {
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    [YarnCommand("nextScene")]
    public void NextScene()
    {
        GameManager.Instance.gameState = GameState.HAME;
        sceneTransitionManager.FadeToScene(StringLiterals.TenementScene);
    }

    [YarnCommand("fadeToBlack")]
    public void FadeToBlack()
    {
        sceneTransitionManager.FadeToBlack();
        StartCoroutine(FindOutIfGotJob());
    }

    IEnumerator FindOutIfGotJob()
    {
        yield return new WaitForSeconds(2f);
        soundManager.PlayPhoneVibration();
        yield return new WaitForSeconds(3.5f);
        dialogueRunner.StartDialogue("Joab.Result");
    }
}
