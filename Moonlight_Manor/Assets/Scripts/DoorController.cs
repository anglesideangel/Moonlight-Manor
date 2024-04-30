using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    //public GameObject obj;
    public TMP_Text text;
    public bool triggerAction = false;
    public bool opened= false;
    public GameObject currentDoor;
    void Start()
    {
        text.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Door")){
            text.gameObject.SetActive(true);
            triggerAction = true;
            currentDoor = collision.transform.parent.gameObject;;
        }
        
    }

    private void OnTriggerExit(Collider collision){
        if (collision.CompareTag("Door"))
        {
            if (opened && collision.gameObject == currentDoor)
            {
                triggerAction = false;
                text.gameObject.SetActive(false);
                //obj.GetComponent<Animator>().Play("DoorClose");
                opened = false;
            }
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            if (triggerAction && currentDoor != null){
                if (!opened ){
                    currentDoor.GetComponent<Animator>().Play("DoorOpen");
                    opened = true;
                } else {
                    currentDoor.GetComponent<Animator>().Play("DoorClose");
                    opened = false;
                }
                
            } 
        }
    }


}
