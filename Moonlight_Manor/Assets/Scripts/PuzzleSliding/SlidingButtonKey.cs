using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlidingButton : MonoBehaviour
{
    public GameObject obj;
  
    public void Confirm(){
        obj.GetComponent<SlidingPuzzle2>().CheckResults();
    }
    public void GoBack(){
        PlayerManager.Instance.Player2.GetComponentInChildren<FPSController>().enabled = true;
        PlayerManager.Instance.Player2.GetComponentInChildren<mouseController>().enabled = true;       
        //SceneManager.LoadSceneAsync("SecondScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("sliding key");
        //SceneManager.LoadScene("Main");
        UIManager.Instance.DisplayInfo();
    }
}
