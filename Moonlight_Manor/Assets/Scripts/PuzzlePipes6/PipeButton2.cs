using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeButton2 : MonoBehaviour
{
    public GameObject obj;
  
    public void Confirm(){
        obj.GetComponent<PipeController2>().CheckResults();
    }
    public void GoBack(){
        PlayerManager.Instance.ActivePlayer.GetComponentInChildren<FPSController>().enabled = true;
        if (PlayerManager.Instance.ActivePlayer.GetComponentInChildren<mouseController>() != null)
        PlayerManager.Instance.ActivePlayer.GetComponentInChildren<mouseController>().enabled = true;       
        //SceneManager.LoadSceneAsync("SecondScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Pipes2");
        //SceneManager.LoadScene("Main");
        UIManager.Instance.DisplayInfo();
        PlayerManager.Instance.mainCamera.enabled = true;
    }
}
