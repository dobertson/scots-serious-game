using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

/*
  *  This script is attached to the 3D words that appear during the first school scene
  */
public class SchoolWord : MonoBehaviour
{
    public GameObject actualCorrectWord;    
    public bool isCorrectWord;
    public string yarnNode;

    private DialogueRunner dialogueRunner;
    private Scuil1Manager scuil1Manager;

    // Start is called before the first frame update
    void Awake()
    {
        if(!isCorrectWord)
        {
            actualCorrectWord.SetActive(false);
        }
        tag = StringLiterals.WordTag;                   // set tag dynamically 
        gameObject.AddComponent<Rigidbody>();           // give it a collider and rigidbody
        gameObject.AddComponent<BoxCollider>();
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Collider>().isTrigger = true;

        dialogueRunner = FindObjectOfType<DialogueRunner>();
        scuil1Manager = FindObjectOfType<Scuil1Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform); // ensure the words are easy to read by having them face the player
    }

    private void OnMouseDrag()
    {
        // code snippet from https://answers.unity.com/questions/496205/mouse-position-seems-to-be-the-same-everytime.html
        // lets player drag the 3D word

        var dist = transform.position.z - Camera.main.transform.position.z;
        var v3Pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);

        var mousePosition = Camera.main.ScreenToWorldPoint(v3Pos);
        mousePosition.z = transform.position.z;

        transform.position = Vector3.MoveTowards(
            transform.position,
            mousePosition,
            Time.deltaTime * 10f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        // if 3D word triggers with the box
        if (collider.gameObject.tag == StringLiterals.WordBoxTag)
        {
            // if there is a dialogue node associated with this word
            if(!string.IsNullOrEmpty(yarnNode))
            {  
                // run the dialogue
                dialogueRunner.StartDialogue(yarnNode);
            }

            // if the word is a Scots word, se the "correct" english word
            // that the teacher will enable when the dialogue has finished
            if(!isCorrectWord)
            {
                scuil1Manager.SetTeacherCorrectionWord(actualCorrectWord);
            }
            scuil1Manager.IsWordGameOver(); // check if all words have been put in box
            gameObject.SetActive(false);    // disable this word as it's now in the box
        }
        
    }
}
