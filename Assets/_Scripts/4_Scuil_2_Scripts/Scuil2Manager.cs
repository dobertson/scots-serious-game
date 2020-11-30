using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class Scuil2Manager : MonoBehaviour
{
    public Transform lookAtTeacherPos;
    public Transform lookAtPalPos;
    public GameObject poemOnTable;

    private void Start()
    {
        poemOnTable.GetComponent<Collider>().enabled = false;
        FindObjectOfType<DialogueRunner>().StartDialogue("Scuil2.Teacher"); //start teacher dialogue
    }

    [YarnCommand("enablePoemPickUp")]
    public void EnablePoemPickUp()
    {
        poemOnTable.GetComponent<Collider>().enabled = true;
    }

    [YarnCommand("teacherInterrupts")]
    public void TeacherInterrupts()
    {
        FindObjectOfType<PlayerLook>().transform.LookAt(lookAtTeacherPos);
    }

    [YarnCommand("nextScene")]
    public void NextScene()
    {
        GameManager.Instance.gameState = GameState.JOAB;
        FindObjectOfType<SceneTransitionManager>().FadeToScene(StringLiterals.TenementScene);
    }

    public void StartTalkingToPal()
    {
        StartCoroutine(StartConvo());
    }

    IEnumerator StartConvo()
    {
        yield return new WaitForSeconds(2f);
        FindObjectOfType<PlayerLook>().transform.LookAt(lookAtPalPos);
        FindObjectOfType<DialogueRunner>().StartDialogue("Scuil2.Pal");
    }
}
