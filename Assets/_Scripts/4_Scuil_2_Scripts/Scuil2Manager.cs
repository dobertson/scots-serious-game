using System.Collections;
using UnityEngine;
using Yarn.Unity;

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

    [YarnCommand("enablePoemPickUp")]
    public void EnablePoemPickUp()
    {
        poemOnTable.GetComponent<Collider>().enabled = true;
    }

    [YarnCommand("teacherInterrupts")]
    public void TeacherInterrupts()
    {
        playerLook.transform.LookAt(lookAtTeacherPos);
    }

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

    IEnumerator StartConvo()
    {
        yield return new WaitForSeconds(2f);
        playerLook.transform.LookAt(lookAtPalPos);
        dialogueRunner.StartDialogue("Scuil2.Pal");
    }
}
