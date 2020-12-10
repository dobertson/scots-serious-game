using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  This class is used on the context notes to rotate them
 */
public class ContextRotateNote : MonoBehaviour
{
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(-10 * Time.deltaTime * speed, 45 * Time.deltaTime * speed, 0);
    }
}
