using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    public static BackgroundSoundPlayer Instance { get; private set; }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }


}
