using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JigsawButtons : MonoBehaviour
{
    public GameObject obj;
  
    public void GoBack(){
        PlayerManager.Instance.ActivePlayer.GetComponentInChildren<FPSController>().enabled = true;
        PlayerManager.Instance.ActivePlayer.GetComponentInChildren<mouseController>().enabled = true;       
        //SceneManager.LoadSceneAsync("SecondScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("Jigsaw");
        //SceneManager.LoadScene("Main");
        UIManager.Instance.DisplayInfo();
        PlayerManager.Instance.mainCamera.enabled = true;
    }
}