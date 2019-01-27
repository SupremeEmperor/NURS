using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activePlayer : MonoBehaviour
{
    public bool active = false;

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
        }
        else
        {
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<grabberscript>().enabled = false;
        }
    }
}
