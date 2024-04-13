using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public GameObject obj;
    public TMP_Text text;
    public bool triggerAction = false;
    public bool opened= false;
    void Start()
    {
        text.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Door")){
        text.gameObject.SetActive(true);
        triggerAction = true;
        }
        
    }

    private void OnTriggerExit(Collider collision){
        if (opened){
            triggerAction = false;
            text.gameObject.SetActive(false);
            //obj.GetComponent<Animator>().Play("DoorClose");
        
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            if (triggerAction){
                if (!opened ){
                    obj.GetComponent<Animator>().Play("DoorOpen");
                    opened = true;
                } else {
                    obj.GetComponent<Animator>().Play("DoorClose");
                    opened = false;
                }
                
            } 
        }
    }


}
