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
       // text.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Door")){
            triggerAction = true;
            currentDoor = collision.transform.parent.gameObject;
            text = currentDoor.GetComponentInChildren<TMP_Text>();
            Debug.Log(text);
            text.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider collision){
        if (collision.CompareTag("Door"))
        {
            if (collision.transform.parent.gameObject == currentDoor)
            {
                triggerAction = false;
                //text.gameObject.SetActive(false);
                //obj.GetComponent<Animator>().Play("DoorClose");
                if (opened) opened = false;
                currentDoor = null;
                Debug.Log(currentDoor);
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
