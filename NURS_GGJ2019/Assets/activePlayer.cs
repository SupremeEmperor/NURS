using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activePlayer : MonoBehaviour
{
    public GameObject player;
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
            player.GetComponent<PlayerMovement>().enabled = true;
        }
        else
        {
            player.GetComponent<PlayerMovement>().enabled = false;
        }
    }
}
