using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public GameObject Player1 { get; private set; }
    public GameObject Player2 { get; private set; }

    public GameObject ActivePlayer { get; set; }

    public Camera mainCamera;
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

    public void Assign(GameObject player){
        if (Player1 == null){
            Player1 = player;
            Debug.Log("Player 1 has joined the game!");
        }
        else if (Player2 == null){
            Player2 = player;
            Debug.Log("Player 2 has joined the game!");
        }
        else{
            Debug.Log("Too many players!");
            throw new InvalidOperationException("Too many players!");
        }
    }
}