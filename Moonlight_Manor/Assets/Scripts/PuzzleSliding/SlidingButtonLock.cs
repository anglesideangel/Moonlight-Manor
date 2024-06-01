using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlidingButtonLock : MonoBehaviour
{
    public void GoBack(){
        PlayerManager.Instance.ActivePlayer.GetComponentInChildren<FPSController>().enabled = true;
        PlayerManager.Instance.ActivePlayer.GetComponentInChildren<mouseController>().enabled = true;       
        //SceneManager.LoadSceneAsync("SecondScene", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync("sliding lock");
        //SceneManager.LoadScene("Main");
        InfoManager.Instance.DisplayInfo();
    }
}
