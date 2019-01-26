using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Vector2 ActivePos;
    public bool active = false;
    public float rate;
    private Rigidbody2D body;
    float extent = 0;

    public void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if(active)
        {
            if(extent >= ActivePos.magnitude)
            {
                body.velocity = Vector2.zero;
                extent = ActivePos.magnitude;
            }
            else
            {
                body.velocity = ActivePos.normalized * rate;
                extent += rate * Time.deltaTime;
            }
        }
        else
        {
            if(extent <= 0)
            {
                body.velocity = Vector2.zero;
                extent = 0;
            }
            else
            {
                body.velocity = ActivePos.normalized * -rate;
                extent -= rate * Time.deltaTime;
            }
        }
    }

    public void Activate()
    {
        active = true;
    }

    public void Deactivate()
    {
        active = false;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position + (Vector3)ActivePos, transform.position);
    }
}
