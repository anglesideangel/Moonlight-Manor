using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetworkConnector : NetworkBehaviour
{    
    public Camera playerCamera;
    public override void OnNetworkSpawn(){
        PlayerManager.Instance.Assign(this.gameObject);

        if (IsLocalPlayer)
            playerCamera.gameObject.SetActive(true);
        else
            playerCamera.gameObject.SetActive(false);
    }
}
