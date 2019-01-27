using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueExit : MonoBehaviour
{
    public Animator animator;

    public void FadeToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void callAnimation()
    {
        animator.SetTrigger("FadeOut");
    }
}
