using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LeakChecker : MonoBehaviour
{
    public static LeakChecker Instance;

    public bool pipes1Completed = false;
    public bool pipes2Completed = false;

    void Awake()
    {
        Instance = this;
    }

    public void CheckBothPuzzlesCompleted()
    {
        if (PipeController.Instance.IsPipes1Completed())
        {
            pipes1Completed = true;
            Debug.Log("pipes");
        }
        if (PipeController2.Instance.IsPipes2Completed())
        {
            pipes2Completed = true;
            Debug.Log("pipes2");
        }
        if (pipes1Completed && pipes2Completed)
        {
            PuzzleManager.Instance.PuzzleCompleted(6);
            // Both puzzles are completed, perform desired action
            Debug.Log("Both puzzles are completed!");
        }
    }
}