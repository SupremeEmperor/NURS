using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DayNextLevel : MonoBehaviour
{
    public Animator animator;
    public GameObject myObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Night_Boy")
        {
            myObject.GetComponent<TrueExit>().callAnimation();
        }
    }
}
