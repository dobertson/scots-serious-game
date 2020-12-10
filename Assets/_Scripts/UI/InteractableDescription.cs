using TMPro;
using UnityEngine;

/*
 *  This class handles showing the UI text that indacates an 
 *  object is interactable when a player hovers over it
 */
public class InteractableDescription : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject textContainer;    // gameobject to hide/show when appropriate

    private void Start()
    {
        textContainer.SetActive(false);
    }

    // show the ui
    public void Show(string description)
    {
        text.text = description;
        textContainer.SetActive(true);
    }

    // hide it
    public void Hide()
    {
        textContainer.SetActive(false);
    }
}
