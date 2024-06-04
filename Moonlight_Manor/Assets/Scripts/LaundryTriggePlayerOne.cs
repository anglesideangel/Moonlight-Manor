
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaundryTriggerPlayerOne : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    
    if (other.CompareTag("Player"))
    {
        
        if (other.transform.parent!= null){
            // can't move the cube if player 2
            if (PlayerManager.Instance.Player2 !=null && other.transform.parent == PlayerManager.Instance.Player2.transform )
            {
                Debug.Log(other);
                Debug.Log(other.transform.parent);
                Rigidbody rb = GetComponentInParent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    rb.isKinematic = true;
                }
            }
            // can move the cube if player 1

            else if (PlayerManager.Instance.Player1 !=null && other.transform.parent == PlayerManager.Instance.Player1.transform )
            {
                Rigidbody rb = GetComponentInParent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;

                    rb.velocity = Vector3.zero;
                   //rb.constraints = RigidbodyConstraints.FreezeAll;
                   // rb.constraints -= ~RigidbodyConstraints.FreezePositionY & ~RigidbodyConstraints.FreezePositionZ & ~RigidbodyConstraints.FreezeRotation;
                    rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

                }
            }
        }
        
    }
    
    // else {
    //     Rigidbody rb = GetComponentInParent<Rigidbody>();
    //     if (rb != null)
    //         {
    //             rb.velocity = Vector3.zero;
                
    //             rb.constraints = RigidbodyConstraints.None;
                
    //             rb.constraints &= ~RigidbodyConstraints.FreezePositionY & ~RigidbodyConstraints.FreezePositionZ & ~RigidbodyConstraints.FreezeRotation;
    //         }
    
    //     }
    }
}