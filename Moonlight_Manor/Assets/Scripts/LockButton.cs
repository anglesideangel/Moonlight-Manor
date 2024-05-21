using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LockButton : MonoBehaviour
{
    public GameObject obj;
    public void Confirm(){
        obj.GetComponent<LockController>().CheckResults();
    }
    public void GoBack(){
        SceneManager.LoadScene("Main");
    }
}
