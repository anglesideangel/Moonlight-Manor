using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorNewSceneController : MonoBehaviour
{
    public bool triggerAction = false;
    public bool opened= false;
    public GameObject currentDoor;
    void Start()
    {
     
    }

    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Player")){
            triggerAction = true;
            SceneManager.LoadScene("SecondScene");
        }
        
    }

    public void OpenDoor()
    {
        if (!opened)
        {
            gameObject.GetComponentInParent<Animator>().Play("DoorOpen");
            opened = true;
        }
    }
  

}
