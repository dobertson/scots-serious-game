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

    private ScrollRect scrollRect;          // ref to the scrollable area

    private void Awake()
    {
        scrollRect = GameObject.FindGameObjectWithTag(StringLiterals.ScrollAreaTag).GetComponent<ScrollRect>();
    }

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

        StartCoroutine(ScrollBottom()); // once text has been added, set scroll to the bottom of the text area
    }

    // once text has added, scroll to bottom of text area 
    IEnumerator ScrollBottom()
    {
        yield return new WaitForEndOfFrame();
        Canvas.ForceUpdateCanvases();
        GameObject.FindGameObjectWithTag(StringLiterals.ScrollAreaTag)
            .GetComponent<ScrollRect>()
            .verticalNormalizedPosition = 0;
    }
    

    // once text has added, scroll to bottom of text area, used in the dialogue runner
    public void ScrollToBottom()
    {
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0;
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
