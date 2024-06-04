using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.Netcode;

public class PuzzleChecker : NetworkBehaviour
{
    public NetworkVariable<bool> puzzle1Completed = new NetworkVariable<bool>(false);
    public NetworkVariable<bool> puzzle2Completed = new NetworkVariable<bool>(false);

    void Start()
    {
        puzzle1Completed.OnValueChanged += OnPuzzleCompleted;
        puzzle2Completed.OnValueChanged += OnPuzzleCompleted;
    }

    [Rpc(SendTo.Server)]
    public void Puzzle2CompletedServerRpc(){
        Debug.Log("Puzzle 2 Completed!");
        puzzle2Completed.Value = true;
    }

    public void Puzzle1Completed(){
        Debug.Log("Puzzle 1 Compelted!");
        puzzle1Completed.Value = true;
    }

    public void OnPuzzleCompleted(bool prev, bool cur)
    {
        if (puzzle1Completed.Value && puzzle2Completed.Value)
        {
            PuzzleManager.Instance.PuzzleCompleted(4);
            Debug.Log("Both puzzles are completed!");
        }
    }
}
