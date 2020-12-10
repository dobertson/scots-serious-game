using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/*
 * This script is used in the faimly scene when you walk into the room
 * and hit a collider that initates conversation with your mum
 */
public class StartDialogueTrigger : MonoBehaviour
{
    public string yarnNode; //dialogue node to talk to 

    private DialogueRunner dialogueRunner;

    void Awake()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == StringLiterals.PlayerTag)
        {
            dialogueRunner.StartDialogue(yarnNode);
            GetComponent<Collider>().enabled = false;
        }
    }
}
