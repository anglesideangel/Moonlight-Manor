using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController characterController;

    public float speed = 12f;


    Vector3 moveVelocity;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (characterController.isGrounded) {
            moveVelocity = transform.right * 4 * x + transform.forward * 4 * z;
            moveVelocity.y = -0.2f;
        
            if (Input.GetKeyDown(KeyCode.Space)){
                moveVelocity.y += 5;
            }
            
        }
        if (!characterController.isGrounded) {
            moveVelocity.y += -9.81f * Time.deltaTime;
        }
        
        characterController.Move(moveVelocity * Time.deltaTime);
    }
}

