using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverSwitch : MonoBehaviour
{
    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    public bool ActivationState;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (ActivationState)
            {
                ActivationState = false;
                OnDeactivate.Invoke();
                Debug.Log("Deactivated");
            }
            else
            {
                ActivationState = true;
                OnActivate.Invoke();
                Debug.Log("Activated");
            }
        }           
    }
}
