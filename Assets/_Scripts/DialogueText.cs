using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string lineID;
    public string text;
    public string translatedText;

    public void SetValues(string lineID, string text, string translatedText)
    {
        this.lineID = lineID;
        this.text = text;
        this.translatedText = translatedText;

        GetComponent<TextMeshProUGUI>().text = this.text;
        transform.SetSiblingIndex(transform.parent.transform.childCount - 2);
    }

    public void ShowTranslation()
    {
        FindObjectOfType<HoverTextTranslation>().SetText(translatedText);
    }

    public void HideTranslation()
    {
        FindObjectOfType<HoverTextTranslation>().HideText();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ShowTranslation();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        HideTranslation();
    }
}
