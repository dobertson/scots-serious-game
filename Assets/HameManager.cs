using System.Collections;
using UnityEngine;
using Yarn.Unity;

public class HameManager : MonoBehaviour
{
    public AudioSource musicPlayer;
    public GameObject endingTextContainer;
    public GameObject hameText;
    public GameObject homeText;

    // Start is called before the first frame update
    void Start()
    {
        endingTextContainer.SetActive(false);
        hameText.SetActive(false);
        homeText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowEndingText()
    {
        musicPlayer.spatialBlend = 0;
        musicPlayer.time = 17f;
        musicPlayer.volume = 0.25f;
        endingTextContainer.SetActive(true);
        StartCoroutine(ReturnToMainMenu());
    }

    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(20f);
        GameManager.Instance.gameState = GameState.MAIN_MENU;
        FindObjectOfType<SceneTransitionManager>().FadeToScene(StringLiterals.TenementScene);
    }

    [YarnCommand("showHameText")]
    public void ShowHameText()
    {
        ShowEndingText();
        hameText.SetActive(true);
    }

    [YarnCommand("showHomeText")]
    public void ShowHomeText()
    {
        ShowEndingText();
        homeText.SetActive(true);
    }
}
