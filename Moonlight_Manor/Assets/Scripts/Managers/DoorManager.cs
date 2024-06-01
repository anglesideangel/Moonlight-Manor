using UnityEngine;
using System.Collections.Generic;

public class DoorManager : MonoBehaviour
{
    public static DoorManager Instance { get; private set; }
    public DoorController[] doorsArray2 = new DoorController[8];
  
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
        doorsArray2[index] = door;
    }


    public void UnlockNextDoor(int order)
    {
        if (order > 0 && order < doorsArray2.Length)
        {
            // for (int i = 0; i <=order; i++) {
            //     if (doorsArray2[i] != null)
            //     {
            //         doorsArray2[i].UnlockDoor();
            //     }
            // }
            doorsArray2[order].UnlockDoor();
        }
    }


}

