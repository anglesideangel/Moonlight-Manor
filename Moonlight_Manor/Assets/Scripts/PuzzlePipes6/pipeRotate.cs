using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PipeType
{
    Line,
    Curve,
    Cross
}

public class pipeRotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };
    public PipeType pipeType; // The type of the pipe
    private int numberRotated;
    void Start()
    {
        numberRotated = 0;

        Cursor.lockState = CursorLockMode.None;
    }

    private void OnMouseDown()
    {
        StartCoroutine("Rotation");
    }

    private IEnumerator Rotation()
    {
        for (int i = 0; i <=4; i++){
            transform.Rotate(0f,18f,0f);
            yield return new WaitForSeconds(0.01f);
        }

        if (pipeType == PipeType.Line)
        {
            // For line pipes, rotate through 0, 1, 0, ...
            numberRotated = (numberRotated + 1) % 2;
        }
        else if (pipeType == PipeType.Cross)
        {
            // For cross pipes, always stay at 0 regardless of rotations
            numberRotated = 0;
        }
        else if (pipeType == PipeType.Curve)
        {
            numberRotated += 1;

            if (numberRotated > 3)
            {
                numberRotated = 0;
            }
        }
        Rotated(name,numberRotated);
    }

    void Update()
    {
        
    }
}
