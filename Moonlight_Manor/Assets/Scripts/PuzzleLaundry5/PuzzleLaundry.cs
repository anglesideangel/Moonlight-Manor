using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.UI;

public class PuzzleLaundry: MonoBehaviour
{
   // public bool isLocked;
    public bool exit;
    void Start()
    {
    }


    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("WashingMachine"))
        {
            PuzzleManager.Instance.PuzzleCompleted(4);
        }
        
    }

    private void OnTriggerExit(Collider collision){
        
    }
    



}
