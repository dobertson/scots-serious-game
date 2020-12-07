using TMPro;
using UnityEngine;
/*
 *  This class handles showing UI text of a translated dialogue line when
 *  the player hovers over a line of dialogue given by an NPC.
 */
public class TranslatedLine : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject textContainer;    // gameobject to hide/show when appropriate
    public Vector3 offset;              // osset from the mouse positon so it doesn't show directly under mouse

    // Start is called before the first frame update
    void Awake()
    {
        textContainer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // move text with mouse cursor
        //transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0) + offset;
    }

    public void Show(string text)
    {
        this.text.text = text;
        textContainer.SetActive(true);
    }

    public void Hide()
    {
        textContainer.SetActive(false);
    }
}
