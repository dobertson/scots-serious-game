using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class lets the player click on the ball and punt it
 */
public class KickBall : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 4f, ForceMode.Impulse); //whebn scene starts, kick ball towards player
    }

    private void OnMouseDown()
    {
        // if close enough
        if (GameManager.Instance.IsPlayerCloseEnough(transform.position))
        {
            var direction = FindObjectOfType<PlayerMove>().transform.forward * 7f; // kick ball in players direction
            direction.y = Random.Range(3f, 10f);                                  // set random height of kick
            
            rb.AddForce(direction, ForceMode.Impulse);          // kick and play kicking sfx
            FindObjectOfType<SoundManager>().PlayBallKickSFX();
        }
    }
}
