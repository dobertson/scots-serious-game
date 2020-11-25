using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class SchoolWord : MonoBehaviour
{
    public GameObject actualCorrectWord;
    public bool isCorrectWord;
    public string yarnNode;

    // Start is called before the first frame update
    void Awake()
    {
        if(!isCorrectWord)
        {
            actualCorrectWord.SetActive(false);
        }
        tag = StringLiterals.WordTag;
        gameObject.AddComponent<Rigidbody>();
        gameObject.AddComponent<BoxCollider>();
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Collider>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    private void OnMouseDrag()
    {
        // code snippet from https://answers.unity.com/questions/496205/mouse-position-seems-to-be-the-same-everytime.html
        var dist = transform.position.z - Camera.main.transform.position.z;
        var v3Pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);

        var mousePosition = Camera.main.ScreenToWorldPoint(v3Pos);
        mousePosition.z = transform.position.z;

        //transform.position = mousePosition;

        transform.position = Vector3.MoveTowards(
            transform.position,
            mousePosition,
            Time.deltaTime * 10f);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == StringLiterals.WordBoxTag)
        {
            if(!string.IsNullOrEmpty(yarnNode))
            {
                FindObjectOfType<DialogueRunner>().StartDialogue(yarnNode);
            }

            if(!isCorrectWord)
            {
                FindObjectOfType<Scuil1Manager>().SetTeacherCorrectionWord(actualCorrectWord);
            }
            FindObjectOfType<Scuil1Manager>().IsWordGameOver();
            gameObject.SetActive(false);
        }
        
    }
}
