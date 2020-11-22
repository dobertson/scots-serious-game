using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolWordTin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == StringLiterals.WordTag)
        {
            Destroy(other.gameObject);
        }
    }
}
