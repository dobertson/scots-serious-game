using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutDownPoem : MonoBehaviour
{
    public GameObject poemOnTable; //ref to other poem gameobejct to enable when putting this down

    private InteractableDescription interactableDescription;
    private SoundManager soundManager;
    private Scuil2Manager scuil2Manager;

    void Awake()
    {
        GetComponent<Collider>().enabled = false; // ensure you can't put poem down immediately 

        interactableDescription = FindObjectOfType<InteractableDescription>();
        soundManager = FindObjectOfType<SoundManager>();
        scuil2Manager = FindObjectOfType<Scuil2Manager>();
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
        interactableDescription.Hide();
        soundManager.PlayNotePickupSFX();
        scuil2Manager.StartTalkingToPal();
        transform.parent.gameObject.SetActive(false);
    }
}
