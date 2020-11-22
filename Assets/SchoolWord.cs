using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolWord : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        tag = StringLiterals.WordTag;
        gameObject.AddComponent<Rigidbody>();
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
    }

    private void OnMouseDrag()
    {
        // code snippet from https://answers.unity.com/questions/496205/mouse-position-seems-to-be-the-same-everytime.html
        var dist = transform.position.z - Camera.main.transform.position.z;
        var v3Pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, dist);

        var mousePosition = Camera.main.ScreenToWorldPoint(v3Pos);
        mousePosition.z = transform.position.z;

        //transform.position = mousePosition;

        transform.position = Vector3.MoveTowards(
            transform.position,
            mousePosition,
            Time.deltaTime * 10f);
    }

}
