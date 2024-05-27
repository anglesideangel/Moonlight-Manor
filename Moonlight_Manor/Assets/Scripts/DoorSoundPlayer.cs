using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    public static DoorSoundPlayer Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
           // DontDestroyOnLoad(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
    }

    public void Play()
    {
            audioSource.Play();
    }


}
