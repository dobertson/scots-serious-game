using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  Helper script to enable main menu UI
 *  
 *  Main Menu exists on Base Objects prefab, so use 
 *  this script to set main menu to active if in very first scene
 */
public class SetUpMainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject mainMenuUIContainer;

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance.gameState == GameState.MAIN_MENU)
        {
            mainMenuUIContainer.SetActive(true);
            mainMenu.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
