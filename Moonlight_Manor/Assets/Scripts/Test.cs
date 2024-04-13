using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    public float var = 20f;
    void Start()
    {
       //Destroy(gameObject,3);
        //Debug.Log("hello");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            //Destroy(gameObject);
            //rb.AddForce(Vector3.up * 500);
        }
        //rb.velocity = Vector3.forward * var;
    }

    private void OnMouseDown(){
        Destroy(gameObject);
    }
}
