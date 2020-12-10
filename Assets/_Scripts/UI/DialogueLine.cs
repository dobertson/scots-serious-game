using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 *  This script is attached the dialogue lines, it holds the line Id, the dialogue text, and it's translation
 */
public class DialogueLine : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string lineID;
    public string text;
    public string translatedText;

    private TranslatedLine translatedLine;

    private void Awake()
    {
        translatedLine = FindObjectOfType<TranslatedLine>();
    }

    public void SetValues(string lineID, string text, string translatedText)
    {
        // yarn syntax cannot handle # syntax, so i've created my own tag to replace here,
        // this is used to highlight instructions to player in dialogue
        text = text.Replace("<playerInstruction>", "<color=#009619><b>");
        text = text.Replace("</playerInstruction>", "</color></b>");
        this.lineID = lineID;
        this.text = text;
        this.translatedText = translatedText;

        GetComponent<TextMeshProUGUI>().text = this.text;
    }

    public void ShowTranslation()
    {
        translatedLine.Show(translatedText);
    }

    public void HideTranslation()
    {
        translatedLine.Hide();
    }

    // if player hovers mouse over text, show the translation
    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTranslation();
    }

    // if player is not hovering over it, hide the translation
    public void OnPointerExit(PointerEventData eventData)
    {
        HideTranslation();
    }
}
