using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public TMP_Text text;
    public bool triggerAction = false;
    public bool opened= false;
    public GameObject currentDoor;
    public bool isLocked = true;
    
    void Start()
    {
       text = gameObject.transform.parent.GetComponentInChildren<TMP_Text>();
       if (gameObject.transform.parent.name == "DoorObject (8)"){
        text.gameObject.SetActive(true);
        isLocked = false;
        }
        else{text.gameObject.SetActive(false);}

    }


    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Player") && !isLocked){
            triggerAction = true;
            text.gameObject.SetActive(true);
        }
        
    }

    private void OnTriggerExit(Collider collision){
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
            if (triggerAction && gameObject != null ){
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
