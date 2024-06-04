using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.UI;
using Unity.Netcode;

public class Pipes2Trigger : NetworkBehaviour
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
        if (collision.gameObject == PlayerManager.Instance.Player2)
        {
            text.gameObject.SetActive(true);
            triggerAction = true;
            PlayerManager.Instance.ActivePlayer = PlayerManager.Instance.Player2; // Set Player 2 as the active player
        }
    }

    private void OnTriggerExit(Collider collision){
        if (collision.gameObject == PlayerManager.Instance.Player2) 
        {
            triggerAction = false;
            text.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && PlayerManager.Instance.ActivePlayer == PlayerManager.Instance.Player2)
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
