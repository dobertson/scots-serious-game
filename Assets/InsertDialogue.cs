using TMPro;
using UnityEngine;

public class InsertDialogue : MonoBehaviour
{
    public Transform textArea;
    public TextMeshProUGUI text;

    public void Test(string line)
    {
        string[] splittedParams = line.Split('@');
        Debug.Log(splittedParams[0]);
        Debug.Log(splittedParams[1]);
        Debug.Log(FindObjectOfType<DialogueTranslated>().Get(splittedParams[0]));

        var newText = Instantiate(text, textArea);
        newText.text = splittedParams[1];
        newText.transform.SetSiblingIndex(textArea.transform.childCount-2);
    }
}
