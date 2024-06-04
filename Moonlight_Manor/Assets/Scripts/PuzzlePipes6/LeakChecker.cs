using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.Netcode;

public class LeakChecker : NetworkBehaviour
{
    public NetworkVariable<bool> pipes1Completed = new NetworkVariable<bool>();
    public NetworkVariable<bool> pipes2Completed = new NetworkVariable<bool>();

    void Start()
    {
        pipes1Completed.OnValueChanged += OnPipeCompleted;
        pipes2Completed.OnValueChanged += OnPipeCompleted;
    }

    [Rpc(SendTo.Server)]
    public void Pipe2CompltedServerRpc(){
        Debug.Log("Pipe 2 Completed!");
        pipes2Completed.Value = true;
    }

    public void Pipe1Completed(){
        Debug.Log("Pipe 1 Completed!");
        pipes1Completed.Value = true;
    }

    public void OnPipeCompleted(bool prev, bool cur)
    {
        if (pipes1Completed.Value && pipes2Completed.Value)
        {
            PuzzleManager.Instance.PuzzleCompleted(6);
            Debug.Log("Both puzzles are completed!");
        }
    }
}