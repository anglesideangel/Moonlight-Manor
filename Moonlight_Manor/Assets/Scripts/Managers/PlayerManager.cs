using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public GameObject Player1 { get; private set; }
    public GameObject Player2 { get; private set; }

    public GameObject ActivePlayer { get; set; }

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
        if (Player1 == null)
            Player1 = player;
        else if (Player2 == null)
            Player2 = player;
        else
            throw new InvalidOperationException("Too many players!");
    }

    void Update(){
        if (Player1 != null) Debug.Log("Player 1 in game!");
        if (Player2 != null) Debug.Log("Player 2 in game!");
    }

}