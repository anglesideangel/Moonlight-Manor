using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerNetworkConnector : NetworkBehaviour
{    
    public Camera playerCamera;
    public Vector3 newStartPosition = new Vector3(9.323404f, 1f, 5.508661f);
    public Vector3 newStartRotation = new Vector3(0, 180, 0);

    public GameObject player1Model;
    public GameObject player2Model;
    string prevScene = "";

    void Start(){
        SceneManager.sceneLoaded += OnSceneLoaded;
        prevScene = SceneManager.GetActiveScene().name;
        MoveCharacter();

        if (IsServer){
            if (IsLocalPlayer) SetModel(true);
            else SetModel(false);
        }
        else {
            if (IsLocalPlayer) SetModel(false);
            else SetModel(true);
        }
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

    public void SetModel(bool p1){
        Debug.Log("Setting mdoel to player " + (p1 ? "1" : "2"));
        Transform curModel = transform.Find("model");
        if (curModel != null) Destroy(curModel.gameObject);

        GameObject newModel = Instantiate(p1 ? player1Model : player2Model, transform);
        newModel.name = "model";

        newModel.transform.localPosition = new Vector3(0f, -1.78f, 0f);
        newModel.transform.localRotation = Quaternion.identity;
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
