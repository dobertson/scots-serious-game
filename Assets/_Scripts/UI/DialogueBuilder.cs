using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBuilder : MonoBehaviour
{
    public Transform textArea;
    public TextMeshProUGUI textPrefab;
    public TextMeshProUGUI speakerPrefab;
    public string currentlySpeaking;

    public void CreateText(string line)
    {
        string[] splitParams = line.Split('@');

        var lineId = splitParams[0];
        var splitText = splitParams[1].Split(':');
        var speaker = splitText[0];
        var text = splitText[1];
        var translatedText = FindObjectOfType<DialogueTranslated>().Get(splitParams[0]);

        if (!speaker.Equals(currentlySpeaking))
        {
            currentlySpeaking = splitText[0];
            var newSpeaker = Instantiate(speakerPrefab, textArea);
            newSpeaker.GetComponent<TextMeshProUGUI>().text = currentlySpeaking;
            newSpeaker.transform.SetSiblingIndex(textArea.transform.childCount - 2);
        }

        var newText = Instantiate(textPrefab, textArea);
        newText.GetComponent<DialogueLine>().SetValues(
            lineId,
            text,
            translatedText);

        StartCoroutine(ScrollToBottom());
    }

    // once text has added, scroll to bottom of text area 
    IEnumerator ScrollToBottom()
    {
        yield return new WaitForEndOfFrame();
        Canvas.ForceUpdateCanvases();
        FindObjectOfType<ScrollRect>().verticalNormalizedPosition = 0;
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
