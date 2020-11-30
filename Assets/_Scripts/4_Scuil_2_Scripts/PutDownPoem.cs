using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDownPoem : MonoBehaviour
{
    public GameObject poemOnTable; //ref to other poem gameobejct to enable when putting this down

    void Awake()
    {
        GetComponent<Collider>().enabled = false; // ensure you can't put poem down immediately 
    }

    private void Start()
    {
        StartCoroutine(LetPlayerPutDownPoem());
    }

    // delay letting the player put the poem down
    IEnumerator LetPlayerPutDownPoem()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<Collider>().enabled = true;
    }

    // when player clicks, disable close up poem, play sfx, enable poem on table
    private void OnMouseDown()
    {
        poemOnTable.SetActive(true);
        poemOnTable.transform.GetChild(0).GetComponent<Collider>().enabled = false;
        FindObjectOfType<InteractableDescription>().Hide();
        FindObjectOfType<SoundManager>().PlayNotePickupSFX();
        FindObjectOfType<Scuil2Manager>().StartTalkingToPal();
        transform.parent.gameObject.SetActive(false);
    }
}
