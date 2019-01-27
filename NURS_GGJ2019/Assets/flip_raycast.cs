using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flip_raycast : MonoBehaviour
{
    private Camera mainCam;
    public float right_position = 0f;
    public float left_position = -2.3f;
    public float y_position = -0.6f;
    
    private Vector3 face_right;
    private Vector3 face_left;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindObjectOfType<Camera>();
        face_right = new Vector3(right_position, y_position, 0);
        face_left = new Vector3(left_position, y_position, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Difference = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if(Difference.x < 0)
        {
            transform.position = transform.parent.position + face_left;
        }
        else
        {
            transform.position = transform.parent.position + face_right;
        }
    }
}
