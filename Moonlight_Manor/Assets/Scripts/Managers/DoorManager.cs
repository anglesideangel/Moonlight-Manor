using UnityEngine;
using System.Collections.Generic;

public class DoorManager : MonoBehaviour
{
    public static DoorManager Instance { get; private set; }
    public DoorController[] doorsArray = new DoorController[7];
  
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void AddDoor(DoorController door, int index)
    {
        doorsArray[index] = door;
    }


    public void UnlockNextDoor(int order)
    {
        if (order > 0 && order < doorsArray.Length)
        {
            // for (int i = 0; i <=order; i++) {
            //     if (doorsArray[i] != null)
            //     {
            //         doorsArray[i].UnlockDoor();
            //     }
            // }
            doorsArray[order].UnlockDoor();
        }
    }


}

