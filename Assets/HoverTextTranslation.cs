using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverTextTranslation : MonoBehaviour
{
    private TextMeshProUGUI textComponent;
    private Image imageComponent;
    public Vector3 offset;

    // Start is called before the first frame update
    void Awake()
    {
        imageComponent = GetComponent<Image>();
        textComponent = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        textComponent.enabled = false;
        imageComponent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0) + offset;
    }

    public void SetText(string text)
    {
        textComponent.text = text;
        textComponent.enabled = true;
        imageComponent.enabled = true;
    }

    public void HideText()
    {
        textComponent.enabled = false;
        imageComponent.enabled = false;
    }
}
