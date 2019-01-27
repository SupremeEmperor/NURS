using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RandomInterval : MonoBehaviour
{
    public UnityEvent[] Activate;
    public Vector2[] intervals;

    private void Awake()
    {
        StartCoroutine(Flick());
    }

    private IEnumerator Flick()
    {
        while(true)
        {
            for(int i = 0; i < intervals.Length; ++i)
            {
                Activate[i].Invoke();
                yield return new WaitForSeconds(Random.Range(intervals[i].x, intervals[i].y));
            }
        }
    }
}
