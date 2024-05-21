using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.UI;


public class LockTrigger : MonoBehaviour
{
    //public GameObject obj;
    public TMP_Text text;
    public bool triggerAction = false;
    public bool opened= false;

    private FPSController playerController;

    
    
    void Start()
    {
        text.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider collision){
       if (collision.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            triggerAction = true;
            
            //playerController = collision.GetComponent<FPSController>();

        }
        
    }

    private void OnTriggerExit(Collider collision){
        if (collision.CompareTag("Player"))
        {
            triggerAction = false;
                text.gameObject.SetActive(false);
        }
        
    }


    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.C)){
    //         if (triggerAction){
    //             if (playerController != null)
    //             {
    //                 playerController.SavePlayerPosition();
    //             }
    //             SceneManager.LoadScene("Lock");
    //         } 
    //     }
    // }
    private Vector3 characterPosition;

    // Other existing code...

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (triggerAction)
            {
                // if (playerController != null)
                // {
                //     // Save character position
                //     characterPosition = playerController.transform.position;
                // }
                SceneManager.LoadScene("Lock");
                if (!opened)
                {
                    opened = true;
                }
                else
                {
                    opened = false;
                }
            }
        }
    }

    // Getter method for character position
    public Vector3 GetCharacterPosition()
    {
        return characterPosition;
    }

   
   
}
