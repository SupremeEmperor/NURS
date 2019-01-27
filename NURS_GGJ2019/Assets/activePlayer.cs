using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activePlayer : MonoBehaviour
{
    public bool active = false;
    public PointAtMouse flashLightPoint;
    public PointAtMouse armPoint;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("SwitchPlayer"))
        {
            active = !active;
        }
        if(active)
        {
            GetComponent<PlayerMovement>().enabled = true;
            GetComponent<grabberscript>().enabled = true;
            flashLightPoint.enabled = true;
            armPoint.enabled = true;
        }
        else
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<grabberscript>().enabled = false;
            armPoint.enabled = false;
            flashLightPoint.enabled = false;
        }
    }
}
