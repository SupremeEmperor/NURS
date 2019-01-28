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
        if(collision.GetComponent<grabberscript>().held == null)
        {
            return;
        }
        if (collision.GetComponent<grabberscript>().held.name == "Doggo Varient" && collision.GetComponent<grabberscript>().held.name == "Doggo")
        {
            myObject.GetComponent<TrueExit>().callAnimation();
        }
        if (collision.gameObject.name == "Night_Boy")
        {
            Boy = true;
        }
        if (collision.GetComponent<grabberscript>().held.name == "Doggo Varient" && collision.GetComponent<grabberscript>().held.name == "Doggo")
        {
            Dog = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<grabberscript>().held == null)
        {
            return;
        }
        if (collision.gameObject.name == "Night_Boy")
        {
            Boy = false;
        }
        if (collision.GetComponent<grabberscript>().held.name == "Doggo Varient" && collision.GetComponent<grabberscript>().held.name == "Doggo")
        {
            Dog = false;
        }
    }


}
