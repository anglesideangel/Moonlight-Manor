using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStartPosition : NetworkBehaviour
{
    
    public Vector3 newStartPosition = new Vector3(9.323404f, 1f, 5.508661f);
    public Vector3 newStartRotation = new Vector3(0, 180, 0);


    // Start is called before the first frame update
    public void Start()
    {
        transform.SetPositionAndRotation(newStartPosition, Quaternion.Euler(newStartRotation));
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        transform.SetPositionAndRotation(newStartPosition, Quaternion.Euler(newStartRotation));
    }

}
