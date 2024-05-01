using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorClosedController : MonoBehaviour
{
    //public GameObject obj;
    //public TMP_Text text;
    void Start()
    {
        //text.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("DoorClosed")){
            TMP_Text collidedText = collision.GetComponent<TMP_Text>();
            Debug.Log(collidedText.text);
            if (collidedText != null)
            {
                Debug.Log("blee");
                collidedText.gameObject.SetActive(true);
            }
            
           }
        
    }

    private void OnTriggerExit(Collider collision){
        if (collision.CompareTag("DoorClosed"))
        {
            TMP_Text collidedText = collision.GetComponentInChildren<TMP_Text>();

            if (collidedText != null)
            {
                collidedText.gameObject.SetActive(false);
            }
        }
        
    }




}
