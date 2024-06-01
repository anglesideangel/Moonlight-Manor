using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLaundry : MonoBehaviour
{

    public int index;
    
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
    if (other.CompareTag("Wall"))
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            LaundryManager.Instance.isGoodPosition[index] = true;
            LaundryManager.Instance.CheckPuzzleCompleted();
        }
    }
}
}
