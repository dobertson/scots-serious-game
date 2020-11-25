using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickBall : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 4f, ForceMode.Impulse);
    }
    private void OnMouseDown()
    {
        if (GameManager.Instance.IsPlayerCloseEnough(transform.position))
        {
            var direction = FindObjectOfType<PlayerMove>().transform.forward * 7f;
            direction.y = Random.Range(3f, 10f);
            
            rb.AddForce(direction, ForceMode.Impulse);
        }
    }
}
