using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class FlipWithMouse : MonoBehaviour
{
    private Camera mainCam;
    private SpriteRenderer sr;

    public void Awake()
    {
        mainCam = GameObject.FindObjectOfType<Camera>();
        sr = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        Vector3 Difference = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        sr.flipX = Difference.x < 0;
    }
}
