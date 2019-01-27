using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeDoggo : MonoBehaviour
{
    public bool active = false;
    private bool activeLock = false;
    private DoggoMovement dm;
    private BoxCollider2D bc;

    private void Awake()
    {
        dm = GetComponent<DoggoMovement>();
        bc = GetComponent<BoxCollider2D>();
    }

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

        if(active) //changes here
        {
            dm.enabled = true;
            bc.sharedMaterial.friction = 0f;
        }
        else
        {
            dm.enabled = false;
            bc.sharedMaterial.friction = 10f;
        }
        print(bc.sharedMaterial.friction);
    }
}
