using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorLaundryController: MonoBehaviour
{
    public TMP_Text text;
    public bool triggerAction = false;
    public bool opened= false;
    public GameObject currentDoor;
    private bool canOpen = true;
    void Start()
    {
       text = gameObject.transform.parent.GetComponentInChildren<TMP_Text>();
       text.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("WashingMachine"))
        {
            Debug.Log("cant open");
            canOpen = false; 
        }
        if (collision.CompareTag("Player")){
            triggerAction = true;
        }
        
    }

    private void OnTriggerExit(Collider collision){
        if (collision.CompareTag("WashingMachine"))
            {
                Debug.Log("can open");
                canOpen = true; 
                text.gameObject.SetActive(true);
            }

        if (collision.CompareTag("Player"))
        {
            triggerAction = false;
            text.gameObject.SetActive(false);
            if (opened) opened = false;
            currentDoor = null;
        
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            if (triggerAction && gameObject != null){
                if (canOpen){
                    if (!opened ){
                    gameObject.GetComponentInParent<Animator>().Play("DoorOpen");
                    opened = true;
                    } else {
                        gameObject.GetComponentInParent<Animator>().Play("DoorClose");
                        opened = false;
                    }
                }
                
                
            } 
        }
    }


}
