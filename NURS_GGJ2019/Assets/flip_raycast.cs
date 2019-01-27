using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip_raycast : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 face_right;
    private Vector3 face_left;
    private Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent;
        mainCam = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Difference = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if(Difference.x < 0)
        {
            //face left
            transform.rotation = new Quaternion(0,180,0,0);
        }
        else
        {
            //face_left right
            transform.rotation = new Quaternion(0,0,0,0);
        }
    }
}
