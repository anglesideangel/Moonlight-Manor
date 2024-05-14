using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetworkConnector : NetworkBehaviour
{    
    public override void OnNetworkSpawn(){
        PlayerManager.Instance.Assign(this.gameObject);
    }
}
