using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeverSwitch : MonoBehaviour
{
    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;

    public bool ActivationState;
    
    public void Activate()
    { 
        if (!ActivationState)
        {
            ActivationState = true;
            OnActivate.Invoke();
        }
        else
        {
            ActivationState = false;
            OnDeactivate.Invoke();
        }
    }

}
