using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
 * This class handles the transitions from scene to scene, 
 */
public class SceneTransitionManager : MonoBehaviour
{
    private string sceneToLoad;
    private bool fadeToBlack;
    private bool shouldLoadScene;
    public Image blackOverlay;

    private void Start()
    {
        fadeToBlack = false;
        shouldLoadScene = false;
        blackOverlay.color = new Color(     // ensure black overlay is transparent on play
                blackOverlay.color.r,
                blackOverlay.color.g,
                blackOverlay.color.b,
                0f);
        blackOverlay.gameObject.SetActive(false); // disable, other player can't click past it
    }

    public void Update()
    {
        //ChangeStateDEBUG();

        // if should be fading to black
        if (fadeToBlack)
        {
            // change transparency over time
            blackOverlay.color = new Color(
                blackOverlay.color.r,
                blackOverlay.color.g,
                blackOverlay.color.b,
                blackOverlay.color.a + Time.deltaTime * 0.75f);

            // and if it is fully black, load the next scene
            if (blackOverlay.color.a >= 1f)
            {
                if (shouldLoadScene)
                {
                    LoadScene(sceneToLoad);
                }
                else
                {
                    fadeToBlack = false;
                }
            }
        }
    }

    // this codes allows me to quickly jump to each scene using the numbers on
    // the keyboard

    //private void ChangeStateDEBUG()
    //{
    //    if (Input.GetKeyDown(KeyCode.Alpha1))
    //    {
    //        GameManager.Instance.gameState = GameState.FAIMLY;
    //        LoadScene(StringLiterals.FaimlyScene);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha2))
    //    {
    //        GameManager.Instance.gameState = GameState.FAIMLY;
    //        LoadScene(StringLiterals.Scuil1Scene);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha3))
    //    {
    //        GameManager.Instance.gameState = GameState.FAIMLY;
    //        LoadScene(StringLiterals.PalsScene);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha4))
    //    {
    //        GameManager.Instance.gameState = GameState.FAIMLY;
    //        LoadScene(StringLiterals.Scuil2Scene);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha5))
    //    {
    //        GameManager.Instance.gameState = GameState.FAIMLY;
    //        LoadScene(StringLiterals.JoabScene);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Alpha6))
    //    {
    //        GameManager.Instance.gameState = GameState.HAME;
    //        LoadScene(StringLiterals.TenementScene);
    //    }
    //}

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

    // used in the job scene where we want to fade to black for a dialogue scene
    // rather than for an immediate scene load
    public void FadeToBlack()
    {
        fadeToBlack = true;
        blackOverlay.gameObject.SetActive(true);
    }


    // fade to black, set scene name to load when fully black
    public void FadeToScene(string sceneName)
    {
        fadeToBlack = true;
        shouldLoadScene = true;
        sceneToLoad = sceneName;
        blackOverlay.gameObject.SetActive(true);
    }
}
