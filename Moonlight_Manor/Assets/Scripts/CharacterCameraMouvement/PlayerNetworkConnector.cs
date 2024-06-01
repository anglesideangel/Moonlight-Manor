using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetworkConnector : NetworkBehaviour
{    
    public Camera playerCamera;
    public Vector3 newStartPosition = new Vector3(9.323404f, 1f, 5.508661f);
    public Vector3 newStartRotation = new Vector3(0, 180, 0);
    string prevScene = "";

    void Start(){
        SceneManager.sceneLoaded += OnSceneLoaded;
        prevScene = SceneManager.GetActiveScene().name;
        MoveCharacter();
    }

    public override void OnNetworkSpawn(){
        PlayerManager.Instance.Assign(this.gameObject);

        if (IsLocalPlayer)
            playerCamera.gameObject.SetActive(true);
        else
            playerCamera.gameObject.SetActive(false);

        prevScene = SceneManager.GetActiveScene().name;
        MoveCharacter();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (prevScene == "TitleScreen")
            MoveCharacter();
        
        prevScene = scene.name;
    }

    void MoveCharacter(){
        Debug.Log("Moving character");
        transform.SetPositionAndRotation(newStartPosition, Quaternion.Euler(newStartRotation));
    }
}
