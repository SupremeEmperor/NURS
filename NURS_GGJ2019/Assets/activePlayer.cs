using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activePlayer : MonoBehaviour
{
    public bool active = false;
    private PlayerMovement pm;
    private grabberscript gs;
    private PointAtMouse[] mouses;

    private void Awake()
    {
        pm = GetComponent<PlayerMovement>();
        gs = GetComponent<grabberscript>();
        mouses = GetComponents<PointAtMouse>();
    }

    void Update()
    {
        if(Input.GetButtonDown("SwitchPlayer"))
        {
            active = !active;
        }
        if(active)
        {
            pm.enabled = true;
            gs.enabled = true;
            foreach(PointAtMouse p in mouses)
            {
                p.enabled = true;
            }
        }
        else
        {
            pm.enabled = false;
            gs.enabled = false;
            foreach(PointAtMouse p in mouses)
            {
                p.enabled = false;
            }
        }
    }
}
