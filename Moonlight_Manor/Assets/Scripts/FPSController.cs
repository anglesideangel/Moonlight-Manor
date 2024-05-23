using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;

//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController characterController;

    public float speed = 12f;

    private string positionKey = "SavedPlayerPosition";

    Vector3 moveVelocity;
    private static FPSController instance;

    [SerializeField]
    private float forceMagnitude=1;    

    
    void Start()
    {
        DontDestroyOnLoad(transform.root.gameObject);
       // LoadPlayerPosition();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
    
        if (characterController.isGrounded) {
            moveVelocity = transform.right * 6 * x + transform.forward * 6 * z;
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                moveVelocity *= 1.5f;
            }
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
