using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorClosedController : MonoBehaviour
{
    //public GameObject obj;
    public TMP_Text text;
    public GameObject currentDoor;
    void Start()
    {
        //text.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("DoorClosed")){
            currentDoor = collision.transform.parent.gameObject;
            text = currentDoor.GetComponentInChildren<TMP_Text>();
        
            if (text != null)
            {
                text.gameObject.SetActive(true);
            }
            
           }
        
    }

    private void OnTriggerExit(Collider collision){
        if (collision.CompareTag("DoorClosed"))
        {
            if (text != null)
            {
                text.gameObject.SetActive(false);
            }
        }
        
    }




}
