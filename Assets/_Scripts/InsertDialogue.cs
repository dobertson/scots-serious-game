using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InsertDialogue : MonoBehaviour
{
    public Transform textArea;
    public TextMeshProUGUI text;

    public void CreateText(string line)
    {
        string[] splittedParams = line.Split('@');
        Debug.Log(splittedParams);
        var newText = Instantiate(text, textArea);
        newText.GetComponent<DialogueText>().SetValues(
            splittedParams[0],
            splittedParams[1],
            FindObjectOfType<DialogueTranslated>().Get(splittedParams[0]));

        //StartCoroutine(ScrollToBottom());
    }

    IEnumerator ScrollToBottom()
    {
        yield return new WaitForEndOfFrame(); 
        FindObjectOfType<ScrollRect>().verticalNormalizedPosition = 0;
    }

    public void ClearText()
    {
        for (int i = 0; i < textArea.transform.childCount - 1; i++)
        {
            Destroy(textArea.GetChild(i).gameObject);
        }
    }
}
