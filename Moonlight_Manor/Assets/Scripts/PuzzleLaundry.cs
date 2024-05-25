using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.UI;

public class PuzzleLaundry: MonoBehaviour
{
    private bool canOpen = true;
   // public bool isLocked;
    
    void Start()
    {
    }


    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("WashingMachine"))
        {
            canOpen = false; 
        }
        
    }

    private void OnTriggerExit(Collider collision){
        if (collision.CompareTag("WashingMachine"))
            {
                PuzzleManager.Instance.PuzzleCompleted(4);
            }
        
    }
    



}
