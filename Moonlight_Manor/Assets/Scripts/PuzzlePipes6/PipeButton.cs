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
        PlayerManager.Instance.Player1.GetComponentInChildren<FPSController>().enabled = true;
        if (PlayerManager.Instance.Player1.GetComponentInChildren<mouseController>() != null)
            PlayerManager.Instance.Player1.GetComponentInChildren<mouseController>().enabled = true;       
        //SceneManager.LoadSceneAsync("SecondScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Pipes");
        //SceneManager.LoadScene("Main");
        UIManager.Instance.DisplayInfo();
        PlayerManager.Instance.mainCamera.enabled = true;
    }
}
