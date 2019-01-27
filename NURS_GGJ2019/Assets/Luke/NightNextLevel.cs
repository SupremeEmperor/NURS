using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NightNextLevel : MonoBehaviour
{
    bool Dog = false;
    bool Boy = false;

    private void Update()
    {
        if(Boy == true && Dog == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
