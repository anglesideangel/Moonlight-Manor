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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            text.gameObject.SetActive(true);
            triggerAction = true;
            if (collision.transform.parent != null)
            {
                PlayerManager.Instance.ActivePlayer = collision.transform.parent.gameObject; 
                Debug.Log(PlayerManager.Instance.ActivePlayer);
            }
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
                PlayerManager.Instance.ActivePlayer.GetComponentInChildren<FPSController>().enabled = false;
                PlayerManager.Instance.ActivePlayer.GetComponentInChildren<mouseController>().enabled = false;
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
   
   
}
