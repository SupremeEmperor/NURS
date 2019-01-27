using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeDoggo : MonoBehaviour
{
    public bool active = false;
    private bool activeLock = false;

    // Update is called once per frame
    void Update()
    {
        if (transform.parent != null)
        {
            activeLock = true;
        }
        else
        {
            activeLock = false;
        }
        if(Input.GetButtonDown("SwitchPlayer"))
        {
            if(!activeLock)
            {
            active = !active;
            }
        }
        if(active)
        {
            GetComponent<DoggoMovement>().enabled = true;
        }
        else
        {
            GetComponent<DoggoMovement>().enabled = false;
        }
    }
}
