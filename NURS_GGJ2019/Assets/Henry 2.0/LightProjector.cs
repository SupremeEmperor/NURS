﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightProjector : MonoBehaviour
{
    int layerMask = ((1 << 23) - 1) - (1 << 15);
    public GameObject projection;
    public GameObject litUp;
    float dist = 100f;
    public bool lit = false;
    public bool Source = false;
    public bool biDirectional;

    public void Project(float theta, Vector3 from)
    {
        lit = true;
        if(litUp != null)
        litUp.SetActive(true);
        projection.SetActive(true);
        
        Vector2 dir = new Vector2(Mathf.Cos(theta / 180f * Mathf.PI), Mathf.Sin(theta/ 180f * Mathf.PI));
        RaycastHit2D hit = Physics2D.Raycast(from, dir, dist, layerMask);

        if(hit.collider != null)
        {
            projection.transform.localScale = new Vector3(hit.distance, projection.transform.localScale.y, 1f);
            projection.transform.position = from + new Vector3(Mathf.Cos(theta / 180f * Mathf.PI), Mathf.Sin(theta / 180f * Mathf.PI), 0f) * hit.distance/2;
            projection.transform.eulerAngles = new Vector3(0, 0, theta);

            Vector2 pAngles = new Vector2(Mathf.Cos(hit.collider.transform.eulerAngles.z * Mathf.PI / 180f), Mathf.Sin(hit.collider.transform.eulerAngles.z * Mathf.PI / 180f));
            Vector2 tAngles = new Vector2(Mathf.Cos(theta * Mathf.PI / 180f), Mathf.Sin(theta * Mathf.PI / 180f));
            float dotProd = Vector2.Dot(pAngles, tAngles);
            if(biDirectional && dotProd < 0)
            {
                return;
            }
            LightProjector p = hit.collider.GetComponent<LightProjector>();
            
            if(p != null && p.lit == false)
            {
                Vector2 reflect = Vector2.Reflect(tAngles, pAngles);
                p.Project(Mathf.Atan2(reflect.y, reflect.x) * 180f / Mathf.PI, hit.point);
            }

            LightSensor s = hit.collider.GetComponent<LightSensor>();
            if(s != null)
            {
                s.Activate();
            }
        }
        else
        {
            projection.transform.localScale = new Vector3(dist, projection.transform.localScale.y, 1);
            projection.transform.position = from + new Vector3(Mathf.Cos(theta / 180f * Mathf.PI), Mathf.Sin(theta / 180f * Mathf.PI), 0f) * dist/2;
            projection.transform.eulerAngles = new Vector3(0, 0, theta);
        }
    }

    public void Update()
    {
        if(Source)
        {
            Project(transform.localEulerAngles.z, transform.position);
        }
    }

    public void LateUpdate()
    {
        if(lit == false)
        {
            if(litUp != null)
            litUp.SetActive(false);
            projection.SetActive(false);
        }
        lit = false;
    }
}
