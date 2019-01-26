using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public bool rotContinuous = false;
    public bool rotThisFrame = false;
    public bool reverse = false;
    public float rotSpeed = 20f;

    public void FixedUpdate()
    {
        if(rotContinuous || rotThisFrame)
        {
            transform.eulerAngles = transform.eulerAngles + new Vector3(0, 0, rotSpeed * Time.fixedDeltaTime * (reverse ? -1 : 1));
        }
        rotThisFrame = false;
    }
}
