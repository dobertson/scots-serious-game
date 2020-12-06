using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBuilder : MonoBehaviour
{
    public Transform textArea;
    public GameObject dialogueLinePrefab;
    public GameObject speakerPrefab;
    public string currentlySpeaking;

    public void CreateText(string speaker, string lineID, string lineText, string lineTextTranslated, bool optionLine = false)
    {
        if (!speaker.Equals(currentlySpeaking))
        {
            currentlySpeaking = speaker;
            var newSpeaker = Instantiate(speakerPrefab, textArea);
            newSpeaker.GetComponent<TextMeshProUGUI>().text = currentlySpeaking;
            newSpeaker.transform.SetSiblingIndex(textArea.transform.childCount - 2);
        }

        var newText = Instantiate(dialogueLinePrefab, textArea);
        newText.GetComponent<DialogueLine>().SetValues(
            lineID,
            lineText,
            lineTextTranslated);

        StartCoroutine(ScrollToBottom());
    }

    // once text has added, scroll to bottom of text area 
    IEnumerator ScrollToBottom()
    {
        yield return new WaitForEndOfFrame();
        Canvas.ForceUpdateCanvases();
        GameObject.FindGameObjectWithTag(StringLiterals.ScrollAreaTag)
            .GetComponent<ScrollRect>()
            .verticalNormalizedPosition = 0;
    }

    public void ClearText()
    {
        currentlySpeaking = "";
        for (int i = 0; i < textArea.transform.childCount - 1; i++)
        {
            Destroy(textArea.GetChild(i).gameObject);
        }
    }
}
