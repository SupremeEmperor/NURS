using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    //use this for animation
    public bool ActivationState;

    public AudioSource SwitchOn;
    public AudioSource SwitchOff;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactor"))
        {
            ActivationState = true;
            OnActivate.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactor"))
        {
            ActivationState = false;
            OnDeactivate.Invoke();
        }
    }
}
