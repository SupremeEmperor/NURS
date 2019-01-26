using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject toFollow;

    public void Update()
    {
        transform.position = new Vector3(toFollow.transform.position.x, toFollow.transform.position.y, transform.position.z);
    }
}
