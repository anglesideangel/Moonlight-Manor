using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class mouseController : NetworkBehaviour
{
    // Start is called before the first frame update

    //public float speed = 1.1f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    
    // Update is called once per frame
    void Update()
    {
       //if(!IsOwner) return;
      //  if (IsLocalPlayer) {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
       // }

    }
}
