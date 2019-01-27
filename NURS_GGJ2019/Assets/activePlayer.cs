using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activePlayer : MonoBehaviour
{
    public bool active = false;
    private PlayerMovement pm;
    private grabberscript gs;
    private PointAtMouse[] mouses;
    private BoxCollider2D bc;

    private void Awake()
    {
        pm = GetComponent<PlayerMovement>();
        gs = GetComponent<grabberscript>();
        mouses = GetComponents<PointAtMouse>();
        bc = GetComponent<BoxCollider2D>();
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
            bc.sharedMaterial.friction = 0f;
            foreach(PointAtMouse p in mouses)
            {
                p.enabled = true;
            }
        }
        else
        {
            pm.enabled = false;
            gs.enabled = false;
            bc.sharedMaterial.friction = 10f;
            foreach(PointAtMouse p in mouses)
            {
                p.enabled = false;
            }
        }
        print("Player" + bc.sharedMaterial.friction);
    }
}
