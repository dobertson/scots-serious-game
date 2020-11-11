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

        var newText = Instantiate(text, textArea);
        newText.GetComponent<DialogueText>().SetValues(
            splittedParams[0],
            splittedParams[1],
            FindObjectOfType<DialogueTranslated>().Get(splittedParams[0]));

        FindObjectOfType<Scrollbar>().value = 0;
    }

    public void ClearText()
    {
        for (int i = 0; i < textArea.transform.childCount - 1; i++)
        {
            Destroy(textArea.GetChild(i).gameObject);
        }
    }
}
