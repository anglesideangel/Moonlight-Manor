using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pipeRotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

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

        numberRotated += 1;

        if (numberRotated > 3){
            numberRotated = 0;
        }
        Rotated(name,numberRotated);
    }

    void Update()
    {
        
    }
}