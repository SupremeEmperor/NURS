using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeDoggo : MonoBehaviour
{
    public bool active = false;
    private bool activeLock = false;
    private DoggoMovement dm;
    private Rigidbody2D rb;

    public RandomSound bork;

    private void Awake()
    {
        dm = GetComponent<DoggoMovement>();
        rb = GetComponent<Rigidbody2D>();
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
                if (!active)
                {
                    bork.Activate();
                }
            }
        }

        if(active) //changes here
        {
            dm.enabled = true;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            dm.enabled = false;
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
