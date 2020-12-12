using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
 * This class is responsible for creating the text that appears
 * in the dialogue UI
 */
public class DialogueBuilder : MonoBehaviour
{
    public Transform textArea;              // the gameobject dialogue lines are instantiated under
    public GameObject dialogueLinePrefab;   // prefab for the dialogue line
    public GameObject speakerPrefab;        // prefbad for the spaker prefab
    public string currentlySpeaking;        // keep record who is currently speaking

    public ScrollRect scrollRect;          // ref to the scrollable area

    public void CreateText(string speaker, string lineID, string lineText, string lineTextTranslated, bool optionLine = false)
    {
        // if next line of text is not the same as the previous speaker
        if (!speaker.Equals(currentlySpeaking))
        {
            currentlySpeaking = speaker;                                                    // set new speaker
            var newSpeaker = Instantiate(speakerPrefab, textArea);                          // create new speaker text
            newSpeaker.GetComponent<TextMeshProUGUI>().text = $"[{currentlySpeaking}]";     // set the text to the speakers name
            newSpeaker.transform.SetSiblingIndex(textArea.transform.childCount - 2);        // move the spaker above the Options in the hierarchy
        }

        // instation new dialogue line
        var newText = Instantiate(dialogueLinePrefab, textArea);
        newText.transform.GetChild(0).GetComponent<DialogueLine>().SetValues(
            lineID,
            lineText,
            lineTextTranslated);
        newText.transform.SetSiblingIndex(textArea.transform.childCount - 2);
    }
    
    // this method is run from the DialogueInterface to scroll to the bottom of dialogue box
    // when new lines are inserted, this prevents the continue and option buttons visible being
    // partially hidden when adding content to the dialogue box
    public void ScrollToBottom()
    {
        StartCoroutine(ScrollBottom());
    }
 
    IEnumerator ScrollBottom()
    {
        // it might be have something to do with the execution Yarn does
        // but I have to delay this by two frames to ensure this happens
        // after everything has been inserted into the dialogue box
        yield return new WaitForSeconds(Time.deltaTime * 2);
        Canvas.ForceUpdateCanvases();
        scrollRect
            .GetComponent<ScrollRect>()
            .verticalNormalizedPosition = 0;
    }

    // when starting conversation, clear the previous conversation text
    public void ClearText()
    {
        currentlySpeaking = "";
        for (int i = 0; i < textArea.transform.childCount - 1; i++)
        {
            Destroy(textArea.GetChild(i).gameObject);
        }
    }
}
