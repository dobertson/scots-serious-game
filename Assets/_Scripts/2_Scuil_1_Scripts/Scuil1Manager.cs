using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/*
 * This script manages the yarn commands for the dialogue, as well
 * as handling the logic for the word game the teacher plays
 */
public class Scuil1Manager : MonoBehaviour
{
    public GameObject teacherCorrectionWord;    // reference to the 3D word the teacher will show when she tells you the correct word
    public SpriteRenderer playerThoughtBubble;  // a "thought bubble" sprite that the words spawn on top of
    public List<GameObject> words;              // list of words to set active over time
    private int index = 0;                      // current index in that list
    private int wordsInBox = 0;                 // count of words that have been put in the box (this is the scots words + english words)

    private SceneTransitionManager sceneTransitionManager;
    private SoundManager soundManager;
    private DialogueRunner dialogueRunner;
    private PlayerController playerController;

    private void Awake()
    {
        playerThoughtBubble.enabled = false; // disable the thought bubble at start
        foreach (GameObject word in words)   // disable the words 
        {
            word.SetActive(false);
        }

        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
        soundManager = FindObjectOfType<SoundManager>();
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        playerController = FindObjectOfType<PlayerController>();
    }

    #region Yarn Commands

    // when teacher finishes talking start the game
    [YarnCommand("startWordGame")]
    public void StartWordGame()
    {
        playerThoughtBubble.enabled = true;
        words[index].SetActive(true);
        StartCoroutine(DisableMovement());
        InvokeRepeating("ShowNextWord", 5f, 5f); // every five seconds, a new word appears in the thought bubble
    }

    // when the teacher tells you the english version of a word, show it
    [YarnCommand("showCorrectWord")]
    public void ShowCorrectWord()
    {
        teacherCorrectionWord.SetActive(true);
        StartCoroutine(DisableMovement());
    }

    // disable player movement 
    [YarnCommand("disableCharacterMovement")]
    public void DisableCharacterMovement()
    {
        StartCoroutine(DisableMovement());
    }

    // scene is over, fade to black, back to tenement scene
    [YarnCommand("leaveScene")]
    public void LeaveScene()
    {
        GameManager.Instance.gameState = GameState.PALS;
        sceneTransitionManager.FadeToScene(StringLiterals.TenementScene);
    }

    #endregion

    // when a player drags a word into the box that has a "correct"/english version
    // set it so that the teacher can spawn it in after she has finished dialogue
    public void SetTeacherCorrectionWord(GameObject word)
    {
        teacherCorrectionWord = word;
    }

    // time to show a new word in the thought bubble
    public void ShowNextWord()
    {
        index++;
        if(index < words.Count)
        {
            words[index].SetActive(true);
            soundManager.PlayPopSFX();
        }
        else
        {
            // no more words, stop repeating this invoke
            CancelInvoke("ShowNextWord");
        }
    }

    // if all words are in box, player teachers final dialogue
    public void IsWordGameOver()
    {
        wordsInBox++;
        if (wordsInBox == 21)
        {
            dialogueRunner.StartDialogue("Teacher.EndOfClass");
        }
    }

    // because the dialogue system enables player movement after finishing a dialogue node,
    // we need to disable the player movement after the teacher finishes speaking so the player
    // can't move away from their desk
    IEnumerator DisableMovement()
    {
        yield return new WaitForEndOfFrame();
        playerController.DisablePlayerMovement();
    }
}
