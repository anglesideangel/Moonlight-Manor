using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PipeButton : MonoBehaviour
{
    public GameObject obj;
  
    public void Confirm(){
        obj.GetComponent<PipeController>().CheckResults();
    }
    public void GoBack(){
        PlayerManager.Instance.ActivePlayer.GetComponentInChildren<FPSController>().enabled = true;
        PlayerManager.Instance.ActivePlayer.GetComponentInChildren<mouseController>().enabled = true;       
        //SceneManager.LoadSceneAsync("SecondScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Pipes");
        //SceneManager.LoadScene("Main");
        InfoManager.Instance.DisplayInfo();
    }
}
