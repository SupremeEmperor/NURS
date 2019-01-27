using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipActive : MonoBehaviour
{
    public GameObject go;
    public bool fuckyousquared = true;

    private void Start()
    {
        StartCoroutine(fuckyou());
    }

    private void OnEnable()
    {
        if(fuckyousquared)
        StartCoroutine(fuckyou());
    }

    private IEnumerator fuckyou()
    {
        go.SetActive(false);
        yield return null;
        go.SetActive(true);
    }
}
