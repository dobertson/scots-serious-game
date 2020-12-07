using UnityEngine;
using Yarn.Unity;

/*
 * This script is used to enabled/disable the relevant game objects depending on
 * what scuil scene we are currently in.
 * 
 * Scene 1 - word lesson with teacher
 * Scene 2 - scene where you can speak Scots and get in trouble by the teacher
 */
public class ScuilSceneManager : MonoBehaviour
{
    public GameObject scene1;
    public Transform scene1StartingPos;
    public GameObject scene2;
    public Transform scene2StartingPos;

    // Start is called before the first frame update
    void Start()
    {
        var player = FindObjectOfType<PlayerMove>().transform;
        if (GameManager.gameState == GameState.SCUIL_1)
        {
            scene1.SetActive(true);
            scene2.SetActive(false);
            player.transform.position = scene1StartingPos.position;
            player.transform.forward = scene1StartingPos.forward;
        }
        else if (GameManager.gameState == GameState.SCUIL_2)
        {
            scene1.SetActive(false);
            scene2.SetActive(true);
            player.transform.position = scene2StartingPos.position;
            player.transform.forward = scene2StartingPos.forward;
            // start dialogue with pal behind you
        }
    }
}
