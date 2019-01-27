using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float activationRadius;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D[] raycastHits = Physics2D.CircleCastAll(gameObject.transform.position, activationRadius, Vector2.one);
            for(int i = 0; i < raycastHits.Length; i++)
            {
                if(raycastHits[i].collider != null)
                {
                    print(raycastHits[i].collider);
                    LeverSwitch leverSwitch = raycastHits[i].collider.GetComponent<LeverSwitch>();
                    if (leverSwitch != null)
                    { 
                        
                        leverSwitch.Activate();
                    }
                }
            }
            
        }
    }
}
