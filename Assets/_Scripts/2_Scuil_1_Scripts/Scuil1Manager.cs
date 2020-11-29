using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/*
 * This script holde
 */
public class Scuil1Manager : MonoBehaviour
{
    public GameObject teacherCorrectionWord;
    public SpriteRenderer playerThoughtBubble;
    public List<GameObject> words;
    private int index = 0;
    private int wordsInBox = 0;

    private void Start()
    {
        playerThoughtBubble.enabled = false;
        foreach (GameObject word in words)
        {
            word.SetActive(false);
        }
    }
    #region Yarn Commands

    [YarnCommand("startWordGame")]
    public void StartWordGame()
    {
        playerThoughtBubble.enabled = true;
        words[index].SetActive(true);
        StartCoroutine(DisableMovement());
        InvokeRepeating("ShowNextWord", 5f, 5f);
    }

    [YarnCommand("showCorrectWord")]
    public void ShowCorrectWord()
    {
        teacherCorrectionWord.SetActive(true);
        StartCoroutine(DisableMovement());
    }

    [YarnCommand("disableCharacterMovement")]
    public void DisableCharacterMovement()
    {
        StartCoroutine(DisableMovement());
    }

    [YarnCommand("leaveScene")]
    public void LeaveScene()
    {
        GameManager.Instance.gameState = GameState.PALS;
        FindObjectOfType<SceneTransitionManager>().LoadScene(StringLiterals.TenementScene);
    }

    #endregion

    public void SetTeacherCorrectionWord(GameObject word)
    {
        teacherCorrectionWord = word;
    }

    public void ShowNextWord()
    {
        index++;
        if(index < words.Count)
        {
            words[index].SetActive(true);
            FindObjectOfType<SoundManager>().PlayPopSFX();
        }
        else
        {
            CancelInvoke("ShowNextWord");
        }
    }

    public void IsWordGameOver()
    {
        wordsInBox++;
        if (wordsInBox == 21)
        {
            FindObjectOfType<DialogueRunner>().StartDialogue("Teacher.EndOfClass");
        }
    }

    // because the dialogue system enables player movement after finishing a dialogue node,
    // we need to disable the player movement after the teacher finishes speaking so the player
    // can't move away from their desk
    IEnumerator DisableMovement()
    {
        yield return new WaitForEndOfFrame();
        FindObjectOfType<PlayerController>().DisablePlayerMovement();
    }
}
