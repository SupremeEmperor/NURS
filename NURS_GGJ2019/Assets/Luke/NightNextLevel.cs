using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightNextLevel : MonoBehaviour
{
    public Animator animator;
    bool Dog = false;
    bool Boy = false;
    grabberscript theScript;
    public GameObject myObject;

    private void Update()
    {
        if(Boy == true && Dog == true)
        {
            myObject.GetComponent<TrueExit>().callAnimation();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<grabberscript>().hit.collider.gameObject.name == "Doggo" )
        {
            myObject.GetComponent<TrueExit>().callAnimation();
        }
        if (collision.gameObject.name == "Night_Boy")
        {
            Boy = true;
        }
        if (collision.gameObject.name == "Doggo")
        {
            Dog = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Night_Boy")
        {
            Boy = false;
        }
        if (collision.gameObject.name == "Doggo")
        {
            Dog = false;
        }
    }


}
