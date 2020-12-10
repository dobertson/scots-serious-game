using System.Collections;
using UnityEngine;
using Yarn.Unity;

/*
 * This script handles the logic in the second scuil scene
 */
public class Scuil2Manager : MonoBehaviour
{
    public Transform lookAtTeacherPos;
    public Transform lookAtPalPos;
    public GameObject poemOnTable;

    private DialogueRunner dialogueRunner;
    private SceneTransitionManager sceneTransitionManager;
    private PlayerLook playerLook;

    private void Awake()
    { 
        poemOnTable.GetComponent<Collider>().enabled = false;

        dialogueRunner = FindObjectOfType<DialogueRunner>();
        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
        playerLook = FindObjectOfType<PlayerLook>();
    }

    private void Start()
    {
        dialogueRunner.StartDialogue("Scuil2.Teacher"); //start teacher dialogue
    }

    // when dialgoue has finished, enable collider so it can be picked up
    [YarnCommand("enablePoemPickUp")]
    public void EnablePoemPickUp()
    {
        poemOnTable.GetComponent<Collider>().enabled = true;
    }

    // when your pal talks to you, the teacher will interupt, so make the player look at
    // the teacher
    [YarnCommand("teacherInterrupts")]
    public void TeacherInterrupts()
    {
        playerLook.transform.LookAt(lookAtTeacherPos);
    }

    // ready for next scene
    [YarnCommand("nextScene")]
    public void NextScene()
    {
        GameManager.Instance.gameState = GameState.JOAB;
        sceneTransitionManager.FadeToScene(StringLiterals.TenementScene);
    }

    public void StartTalkingToPal()
    {
        StartCoroutine(StartConvo());
    }

    // when poem has been put down, wait two seconds before 
    // your pals starts conversation with you
    IEnumerator StartConvo()
    {
        yield return new WaitForSeconds(2f);
        playerLook.transform.LookAt(lookAtPalPos);
        dialogueRunner.StartDialogue("Scuil2.Pal");
    }
}
