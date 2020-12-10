using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class lets the player click on the ball and kick it
 */
public class KickBall : MonoBehaviour
{
    private Rigidbody rb;

    private SoundManager soundManager;
    private PlayerMove playerMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        soundManager = FindObjectOfType<SoundManager>();
        playerMove = FindObjectOfType<PlayerMove>();

    }

    private void Start()
    {
        rb.AddForce(transform.forward * 4f, ForceMode.Impulse); //when scene starts, kick ball towards player
    }

    private void OnMouseDown()
    {
        // if close enough
        if (GameManager.IsPlayerCloseEnough(transform.position))
        {
            var direction = playerMove.transform.forward * 7f;  // kick ball in players direction
            direction.y = Random.Range(3f, 10f);                 // set random height of kick
            
            rb.AddForce(direction, ForceMode.Impulse);          // kick and play kicking sfx
            soundManager.PlayBallKickSFX();
        }
    }
}
