using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.UI;


public class LetterTrigger : MonoBehaviour
{
    //public GameObject obj;
    public TMP_Text text;
    public bool triggerAction = false;
    public bool displayHint = false;
    
    
    void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            triggerAction = true;
        }
    }

    private void OnTriggerExit(Collider collision){
        if (collision.CompareTag("Player"))
        {
            triggerAction = false;
            text.gameObject.SetActive(false);
        }
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (triggerAction)
            {
                if (!displayHint){
                    PuzzleManager.Instance.DisplayFirstHint();
                    displayHint = true;
                }
                else {
                    PuzzleManager.Instance.HideFirstHint();
                    displayHint = false;
                }
            }
        }
    }
   
   
}
