using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class JoabManager : MonoBehaviour
{
    [YarnCommand("nextScene")]
    public void NextScene()
    {
        GameManager.Instance.gameState = GameState.HAME;
        FindObjectOfType<SceneTransitionManager>().FadeToScene(StringLiterals.TenementScene);
    }

    [YarnCommand("fadeToBlack")]
    public void FadeToBlack()
    {
        FindObjectOfType<SceneTransitionManager>().FadeToBlack();
        StartCoroutine(FindOutIfGotJob());
    }

    IEnumerator FindOutIfGotJob()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<SoundManager>().PlayPhoneVibration();
        yield return new WaitForSeconds(3.5f);
        FindObjectOfType<DialogueRunner>().StartDialogue("Joab.Result");
    }
}
