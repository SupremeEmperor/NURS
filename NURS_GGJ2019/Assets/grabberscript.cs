using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabberscript : MonoBehaviour
{
    public bool grabbed = false;
    public RaycastHit2D hit;
    public float distance = 1f;
    public Transform grabpoint;
    public float throwForce = 1f;
    public Transform grabToPoint;
    private Camera mainCam;
    private float throwModifier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindObjectOfType<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 Difference = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if(Difference.x < 0)
        {
            throwModifier = -1f;
        }
        else
        {
            throwModifier = 1f;
        }

        if (Input.GetButtonDown("Pickup"))
        {
            if(!grabbed)
            {
            //grab
            if(Difference.x < 0)
            {
                hit = Physics2D.Raycast(grabToPoint.position, Vector2.left*transform.localScale.x, distance);
            }
            else
            {
                hit = Physics2D.Raycast(grabToPoint.position, Vector2.right*transform.localScale.x, distance);
            }
                if(hit.collider != null && hit.collider.gameObject.GetComponent("Grabbable") != null)
                {
                    grabbed = true;
                    hit.collider.gameObject.transform.parent = transform;
                    hit.collider.gameObject.transform.position = grabpoint.position;
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    GetComponent<BoxCollider2D>().enabled = true;
                }
            }
            else
            {
                //drop
                grabbed = false;
                if(hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.transform.parent = null;
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwForce * new Vector2(throwModifier, 1);
                    print(new Vector2(transform.localScale.x, 1) * throwForce * throwModifier);
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
        if(grabbed)
        {
            hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(grabToPoint.position, grabToPoint.position + Vector3.right*transform.localScale.x * distance * throwModifier);
    }
}
