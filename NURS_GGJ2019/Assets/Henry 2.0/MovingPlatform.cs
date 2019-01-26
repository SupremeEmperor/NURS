using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    public Vector2 ActivePos;
    private Vector2 OriginPos;
    public bool active = false;
    public float rate;
    private Rigidbody2D body;
    float extent = 0;

    public void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        OriginPos = transform.position;
    }

    public void FixedUpdate()
    {
        if(active)
        {
            if(extent >= ActivePos.magnitude)
            {
                body.velocity = Vector2.zero;
                transform.position = OriginPos + ActivePos;
                extent = ActivePos.magnitude;
            }
            else
            {
                body.velocity = ActivePos.normalized * rate;
                extent += rate * Time.fixedDeltaTime;
            }
        }
        else
        {
            if(extent <= 0)
            {
                body.velocity = Vector2.zero;
                extent = 0;
                transform.position = OriginPos;
            }
            else
            {
                body.velocity = ActivePos.normalized * -rate;
                extent -= rate * Time.fixedDeltaTime;
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
