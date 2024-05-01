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
    
    
    void Start()
    {
        text.gameObject.SetActive(false);
    }


    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Lock")){
            
            text.gameObject.SetActive(true);
            triggerAction = true;
        }
        
    }

    private void OnTriggerExit(Collider collision){
        if (collision.CompareTag("Lock"))
        {
            if (opened)
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
        if (Input.GetKeyDown(KeyCode.C)){
            if (triggerAction){
               // SavePlayerPosition();
                SceneManager.LoadScene("Lock");
                
                if (!opened ){
                    opened = true;
                } else {
                    opened = false;
                }
                
            } 
        }
    }

    void SavePlayerPosition()
    {
        PlayerPrefs.SetFloat("X", 2);// transform.position.x);
        PlayerPrefs.SetFloat("Y",2);// transform.position.y);
        PlayerPrefs.SetFloat("Z", 2);//transform.position.z);

        Debug.Log(PlayerPrefs.GetFloat("PlayerX"));
        Debug.Log(PlayerPrefs.GetFloat("PlayerY"));
        Debug.Log(PlayerPrefs.GetFloat("PlayerZ"));
       // PlayerPrefs.SetInt("PlayerPositionInitialized", 1);
        
        //PlayerPrefs.Save();
    }

}
