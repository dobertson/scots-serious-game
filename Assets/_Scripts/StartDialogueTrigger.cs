using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class StartDialogueTrigger : MonoBehaviour
{
    public string yarnNode;
    public Transform lookAtPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == StringLiterals.PlayerTag)
        {
            FindObjectOfType<DialogueRunner>().StartDialogue(yarnNode);
            GetComponent<Collider>().enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
