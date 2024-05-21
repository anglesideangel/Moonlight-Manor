using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotate : MonoBehaviour
{

    public static event Action<string, int> Rotated = delegate { };

    private int numberDisplayed;
    // Start is called before the first frame update
    void Start()
    {
        numberDisplayed = 0;

        Cursor.lockState = CursorLockMode.None;
    }

    private void OnMouseDown()
    {
        StartCoroutine("RotationWheel");
    }

    private IEnumerator RotationWheel()
    {
        for (int i = 0; i <=11; i++){
            transform.Rotate(0f,0f,-3f);
            yield return new WaitForSeconds(0.01f);
        }

        numberDisplayed += 1;

        if (numberDisplayed >9){
            numberDisplayed = 0;
        }
        Rotated(name,numberDisplayed);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
