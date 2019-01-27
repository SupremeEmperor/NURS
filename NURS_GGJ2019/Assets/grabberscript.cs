using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabberscript : MonoBehaviour
{
    public bool grabbed = false;
    RaycastHit2D hit;
    public float distance = 1f;
    public Transform grabpoint;
    public float throwForce = 1f;
    public LayerMask notGrabbed;
    public GameObject player;
    public Transform grabToPoint;
    private Camera mainCam;
    private float throwModifier = 1f;
    public AudioSource pickupSound;
    public AudioSource dropSound;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindObjectOfType<Camera>();
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Pickup"))
        {
            if(!grabbed)
            {
                //grab
                hit = Physics2D.Raycast(grabToPoint.position, Vector2.right*transform.localScale.x, distance);
                if(hit.collider != null && hit.collider.gameObject.GetComponent("Grabbable") != null)
                {
                    grabbed = true;
                    hit.collider.gameObject.transform.parent = player.transform;
                    hit.collider.gameObject.transform.position = grabpoint.position;
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                    hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    player.GetComponent<BoxCollider2D>().enabled = true;
                    pickupSound.Play();
                }
            }
            else if(!Physics2D.OverlapPoint(grabpoint.position,notGrabbed))
            //else
            {
                //drop
                grabbed = false;
                if(hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.transform.parent = null;
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwForce * throwModifier;
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                    hit.collider.gameObject.GetComponent<BoxCollider2D>().enabled = true;
                    player.GetComponent<BoxCollider2D>().enabled = false;
                    dropSound.Play();
                }
            }
        }
        if(grabbed)
        {
            hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        }

        Vector3 Difference = mainCam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        if(Difference.x < 0)
        {
            throwModifier = -1f;
        }
        else
        {
            throwModifier = 1f;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(grabToPoint.position, grabToPoint.position + Vector3.right*transform.localScale.x * distance);
    }
}
