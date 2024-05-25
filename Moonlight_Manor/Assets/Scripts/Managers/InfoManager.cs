using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.UI;

public class InfoManager : MonoBehaviour
{
    
    public static InfoManager Instance { get; private set; }

    public GameObject info;
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    public void DisplayInfo(){
        info.SetActive(true);
    }
    public void HideInfo(){
        info.SetActive(false);
    }


   
}