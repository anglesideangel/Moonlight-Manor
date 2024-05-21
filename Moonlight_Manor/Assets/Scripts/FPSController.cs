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
    // public void SavePlayerPosition()
    // {
    //     PlayerPrefs.SetString(positionKey, transform.root.position.ToString());
    // }

    // private void LoadPlayerPosition()
    // {
        
    //     string savedPositionString = PlayerPrefs.GetString(positionKey, string.Empty);
    //     if (!string.IsNullOrEmpty(savedPositionString))
    //     {
    //         transform.root.position = StringToVector3(savedPositionString);
    //     }
    // }
    
    // private Vector3 StringToVector3(string sVector)
    // {
    //     if (sVector.StartsWith("(") && sVector.EndsWith(")"))
    //     {
    //         sVector = sVector.Substring(1, sVector.Length - 2);
    //     }

    //     string[] sArray = sVector.Split(',');
    //     return new Vector3(
    //         float.Parse(sArray[0]),
    //         float.Parse(sArray[1]),
    //         float.Parse(sArray[2]));
    // }
    

    // private void OnControllerColliderHit(ControllerColliderHit hit)
    // {
    //     var rigidBody = hit.collider.attachedRigidbody;

    //     if (rigidBody != null)
    //     {
    //         var forceDirection = hit.gameObject.transform.position - transform.position;
    //         forceDirection.y = 0;
    //         forceDirection.Normalize();
            
    //         rigidBody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);

            
    //     }
    // }
}

