using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class JoabManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [YarnCommand("nextScene")]
    public void NextScene()
    {
        GameManager.Instance.gameState = GameState.HAME;
        FindObjectOfType<SceneTransitionManager>().FadeToScene(StringLiterals.TenementScene);
    }
}
