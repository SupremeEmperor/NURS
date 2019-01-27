using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAtMouse : MonoBehaviour
{
    private Camera mainCam;

    public void Awake()
    {
        mainCam = GameObject.FindObjectOfType<Camera>();
    }

    public void Update()
    {
        Vector3 Difference = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2(Difference.y, Difference.x) * 180 / Mathf.PI);
    }
}
