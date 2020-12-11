using UnityEngine;

// state represented by which scene the player is currently experiencing
public enum GameState
{
    MAIN_MENU = 0,
    FAIMLY = 1,
    SCUIL_1 = 2,
    PALS = 3,
    SCUIL_2 = 4,
    JOAB = 5,
    HAME = 6
}

public class GameManager : MonoBehaviour
{
    public GameState gameState;
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private void Awake()
    {
        // ensure there is only one game manager
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    // used to determine if player is close enough to an object to
    // interact with it, talk to NPC or load new scene
    public static bool IsPlayerCloseEnough(Vector3 objectPosition)
    {
        var minumDistance = 4f;
        var playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        var distanceFromObject = Vector3.Distance(playerPosition, objectPosition);

        // is custom distance has been specifiedm, use that distance instead
        if (distanceFromObject < minumDistance)
        {
            return true;
        }

        return false;
    }
}


