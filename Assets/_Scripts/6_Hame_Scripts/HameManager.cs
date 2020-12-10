using System.Collections;
using UnityEngine;
using Yarn.Unity;

/*
 * Handles logic for the final scene
 */
public class HameManager : MonoBehaviour
{
    public AudioSource musicPlayer;         // control the music being played at hame
    public GameObject endingTextContainer;  // container for the HAME/HOME ui that shows when the player makes a choice
    public GameObject hameText;
    public GameObject homeText;

    private SceneTransitionManager sceneTransitionManager;

    // Start is called before the first frame update
    void Awake()
    {
        endingTextContainer.SetActive(false);
        hameText.SetActive(false);
        homeText.SetActive(false);

        sceneTransitionManager = FindObjectOfType<SceneTransitionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowEndingText()
    {
        musicPlayer.spatialBlend = 0;           // make music 2D
        musicPlayer.time = 16f;                 // jump to best bit of the track
        musicPlayer.volume = 0.25f;             // increase the volume
        endingTextContainer.SetActive(true);    // show the cointainer for the HAME or HOME text
        StartCoroutine(ReturnToMainMenu());
    }

    IEnumerator ReturnToMainMenu()
    {
        yield return new WaitForSeconds(20f); // let music play for a bit before jumping back to main menu
        GameManager.Instance.gameState = GameState.MAIN_MENU;
        sceneTransitionManager.FadeToScene(StringLiterals.TenementScene);
    }

    // player chose hame, show HAME text
    [YarnCommand("showHameText")]
    public void ShowHameText()
    {
        ShowEndingText();
        hameText.SetActive(true);
    }

    // player chose home, show HOME text
    [YarnCommand("showHomeText")]
    public void ShowHomeText()
    {
        ShowEndingText();
        homeText.SetActive(true);
    }
}
