﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activePlayer : MonoBehaviour
{
    public bool active = false;
    private PlayerMovement pm;
    private grabberscript gs;
    //private PointAtMouse[] mouses;
    private Rigidbody2D rb;
    private SpriteRenderer a;

    public GameObject arrow;

    private void Awake()
    {
        pm = GetComponent<PlayerMovement>();
        gs = GetComponent<grabberscript>();
        //mouses = GameObject.FindObjectsOfType<PointAtMouse>();
        rb = GetComponent<Rigidbody2D>();
        a = arrow.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(Input.GetButtonDown("SwitchPlayer"))
        {
            active = !active;
        }
        if(active) //changes
        {
            pm.enabled = true;
            gs.enabled = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            /*foreach(PointAtMouse p in mouses)
            {
                p.enabled = true;
            }*/
            a.enabled = true;
        }
        else
        {
            pm.enabled = false;
            gs.enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            /*foreach(PointAtMouse p in mouses)
            {
                p.enabled = false;
            }*/
            a.enabled = false;
        }
    }
}
