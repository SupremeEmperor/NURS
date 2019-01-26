using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LightProjector))]
public class Flicker : MonoBehaviour
{

    LightProjector lp;

    private void Awake()
    {
        lp = GetComponent<LightProjector>();
        StartCoroutine(Flick());
    }

    private IEnumerator Flick()
    {
        while(true)
        {
            lp.Source = true;
            yield return new WaitForSeconds(Random.Range(0.5f, 2f));
            lp.Source = false;
            yield return new WaitForSeconds(0.05f);
            lp.Source = true;
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            lp.Source = false;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
