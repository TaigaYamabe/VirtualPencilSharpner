using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    void Update()
    {
        
        if (Input.GetKey("right"))
        {
            //transform.position += transform.forward * -0.01f;
            transform.Rotate(0, 0, 2);
        }

        if (Input.GetKey("left"))
        {
            transform.position += transform.forward * -0.001f;
            transform.Rotate(0, 0, -2);
        }
    }
}