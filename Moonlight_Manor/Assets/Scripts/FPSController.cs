using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Unity.Netcode;
public class FPSController : NetworkBehaviour,IDataPersistence
{
    // Start is called before the first frame update
    public CharacterController characterController;

    public float speed = 12f;


    Vector3 moveVelocity;

    void Start()
    {
        //LoadPlayerPosition();
       
    }

    // Update is called once per frame
    void Update()
    {
        //if(!IsOwner) return;
       // if (IsLocalPlayer) {
        Debug.Log(IsOwner);
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
       // }
    }

    void LoadPlayerPosition()
    {
        // checks if the key exists in PlayerPrefs 
        // so if PlayerX, PlayerY and PlayerZ exist, then
        // Check if the player's position has been initialized

        if (PlayerPrefs.HasKey("X") && PlayerPrefs.HasKey("Y") && PlayerPrefs.HasKey("Z"))
            {
                // Load the previous player position
                Vector3 playerPosition = new Vector3(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"), PlayerPrefs.GetFloat("Z"));
                transform.position = playerPosition;
            }
    }
    public void LoadData(GameData data){
        this.transform.position = data.playerPosition;
    }
    public void SaveData(ref GameData data){
        data.playerPosition = this.transform.position;
    }
}


