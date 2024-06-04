using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlidingButtonLock : MonoBehaviour
{
    public GameObject obj;
  
    public void Confirm(){
        obj.GetComponent<SlidingPuzzle1>().CheckResults();
    }
    public void GoBack(){
        PlayerManager.Instance.Player1.GetComponentInChildren<FPSController>().enabled = true;
        PlayerManager.Instance.Player1.GetComponentInChildren<mouseController>().enabled = true;       
        //SceneManager.LoadSceneAsync("SecondScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("sliding lock");
        //SceneManager.LoadScene("Main");
        UIManager.Instance.DisplayInfo();
    }
}
