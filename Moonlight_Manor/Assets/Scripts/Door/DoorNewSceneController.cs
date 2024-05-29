using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorNewSceneController : MonoBehaviour
{
    bool collided =false;
    private void OnTriggerEnter(Collider collision){
        if (collision.CompareTag("Player")){
            if (!collided)
            {
                SceneManager.LoadScene("EndScene", LoadSceneMode.Additive);
                collided = true;
            }
        }
    }
}
