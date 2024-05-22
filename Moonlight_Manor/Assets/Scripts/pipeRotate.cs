using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeRotate : MonoBehaviour
{
    void Start()
    {
        
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
    }

    void Update()
    {
        
    }
}
