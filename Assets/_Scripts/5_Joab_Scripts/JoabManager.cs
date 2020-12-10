using System.Collections;
using UnityEngine;
using Yarn.Unity;

/*
 * Handles logic for job interview scene
 */
public class JoabManager : MonoBehaviour
{
    private SceneTransitionManager sceneTransitionManager;
    private DialogueRunner dialogueRunner;
    private SoundManager soundManager;
    private PlayerController playerController;

    private void Awake()
    {
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        soundManager = FindObjectOfType<SoundManager>();
        playerController = FindObjectOfType<PlayerController>();
    }

    // load to next scene
    [YarnCommand("nextScene")]
    public void NextScene()
    {
        GameManager.Instance.gameState = GameState.HAME;
        sceneTransitionManager.FadeToScene(StringLiterals.TenementScene);
    }

    // fade screen to black, waiting for phone call about job result
    [YarnCommand("fadeToBlack")]
    public void FadeToBlack()
    {
        playerController.DisablePlayerMovement();
        sceneTransitionManager.FadeToBlack();
        StartCoroutine(FindOutIfGotJob());
    }

    // after two seconds when screen has fade to black, play phone vibration sfx
    // after 3.5 seconds start the dialogue when the receptionists tells you if you
    // did or did not get the job
    IEnumerator FindOutIfGotJob()
    {
        yield return new WaitForSeconds(2f);
        soundManager.PlayPhoneVibration();
        yield return new WaitForSeconds(3.5f);
        dialogueRunner.StartDialogue("Joab.Result");
    }
}
