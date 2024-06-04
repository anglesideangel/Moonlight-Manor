using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PuzzleChecker : MonoBehaviour
{
    public static PuzzleChecker Instance;

    public bool puzzle1Completed = false;
    public bool puzzle2Completed = false;

    void Awake()
    {
        Instance = this;
    }

    public void CheckBothPuzzles()
    {
        if (SlidingPuzzle1.Instance.IsPuzzle1Completed())
        {
            puzzle1Completed = true;
            Debug.Log("lock");
        }
        if (SlidingPuzzle2.Instance.IsPuzzle2Completed())
        {
            puzzle2Completed = true;
            Debug.Log("keys");
        }
        if (puzzle1Completed && puzzle2Completed)
        {
            PuzzleManager.Instance.PuzzleCompleted(4);
            // Both puzzles are completed, perform desired action
            Debug.Log("Both puzzles are completed!");
        }
    }
}
