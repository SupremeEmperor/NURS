using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightSensor : MonoBehaviour
{
    public UnityEvent OnActivate;
    public UnityEvent OnDeactivate;
    public bool lit = false;
    public GameObject litUp;

    public void Activate()
    {
        if(lit == false)
        {
            litUp.SetActive(true);
            OnActivate.Invoke();
        }
        lit = true;
    }

    public void LateUpdate()
    {
        if(lit == false)
        {
            litUp.SetActive(false);
            OnDeactivate.Invoke();
        }
        lit = false;
    }
}
