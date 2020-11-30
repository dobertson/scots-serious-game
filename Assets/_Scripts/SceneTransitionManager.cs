using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : MonoBehaviour
{
    private string sceneToLoad;
    private bool fadeToBlack;
    public Image blackOverlay;

    private void Start()
    {
        fadeToBlack = false;
        blackOverlay.color = new Color(     // ensure black overlay is transparent on play
                blackOverlay.color.r,
                blackOverlay.color.g,
                blackOverlay.color.b,
                0f);
        blackOverlay.gameObject.SetActive(false); // disable, other player can't click past it
    }

    public void Update()
    {
        if (fadeToBlack)
        {
            blackOverlay.color = new Color(
                blackOverlay.color.r,
                blackOverlay.color.g,
                blackOverlay.color.b,
                blackOverlay.color.a + Time.deltaTime * 0.75f);

            if (blackOverlay.color.a >= 1f)
            {
                LoadScene(sceneToLoad);
            }
        }
    }

    // quit application or stop playing if in unity editor
    public void ExitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #endif

        Application.Quit();
    }

    // given scene name, load that scene
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void FadeToScene(string sceneName)
    {
        fadeToBlack = true;
        sceneToLoad = sceneName;
        blackOverlay.gameObject.SetActive(true);
    }
}
