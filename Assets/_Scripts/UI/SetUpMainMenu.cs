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

    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.gameState == GameState.MAIN_MENU)
        {
            mainMenu.SetActive(true);
        }
    }
}
