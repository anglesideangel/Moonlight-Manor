using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.UI;
using Unity.Netcode;

public class Player1Trigger : NetworkBehaviour
{
    public TMP_Text text;
    public bool triggerAction = false;
    public string newSceneName;

    void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.parent == PlayerManager.Instance.Player1.transform)
        {
            text.gameObject.SetActive(true);
            triggerAction = true;
            if (collision.transform.parent != null)
            {
                PlayerManager.Instance.ActivePlayer = collision.transform.parent.gameObject; 
            }
        }
    }

    private void OnTriggerExit(Collider collision){
        if (collision.transform.parent == PlayerManager.Instance.Player1.transform)
        {
            triggerAction = false;
                text.gameObject.SetActive(false);
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) &&  PlayerManager.Instance.ActivePlayer == PlayerManager.Instance.Player1)
        {
            if (triggerAction)
            {
                PlayerManager.Instance.ActivePlayer.GetComponentInChildren<FPSController>().enabled = false;
                PlayerManager.Instance.ActivePlayer.GetComponentInChildren<mouseController>().enabled = false;
                SceneManager.LoadScene(newSceneName, LoadSceneMode.Additive);
                UIManager.Instance.HideInfo();
            }
        }
    }
   
   
}
