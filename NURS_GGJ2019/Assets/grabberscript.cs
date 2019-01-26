using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabberscript : MonoBehaviour
{
    public bool grabbed = false;
    RaycastHit2D hit;
    public float distance = 1f;
    public Transform grabpoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Pickup"))
        {
            if(!grabbed)
            {
                //grab
                
                hit = Physics2D.Raycast(transform.position, Vector2.right*transform.localScale.x, distance);
                if(hit.collider != null){
                    grabbed = true;
                }
            }
            else
            {
                //drop
            }
        }
        if (grabbed){
            hit.collider.gameObject.transform.position = grabpoint.position;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right*transform.localScale.x * distance);
    }
}
