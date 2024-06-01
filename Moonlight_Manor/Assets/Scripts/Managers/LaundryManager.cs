using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class LaundryManager : MonoBehaviour
{
    public Canvas[] canvas = new Canvas[2];

    public bool[] isGoodPosition = new bool[2]; // all false
   
    public static LaundryManager Instance { get; private set; }

    private AudioSource audioSource;
    public GameObject soundEnd;

    public GameObject stackMachines;
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
       
        Rigidbody rb = stackMachines.GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic =true;

        audioSource = GetComponent<AudioSource>();
        //rb.velocity = Vector3.zero;
        //rb.constraints = RigidbodyConstraints.FreezeAll;
    }


    public bool CheckPuzzleCompleted()
    {
        foreach (bool b in isGoodPosition)
        { 
            if (b== false)
            {
                return false; 
            }
        }
        

        Rigidbody rb = stackMachines.GetComponent<Rigidbody>();
        if (rb != null) {
            rb.isKinematic = false;
        }
        if (soundEnd != null)
        {
            SoundEndLaundryController sound = soundEnd.GetComponent<SoundEndLaundryController>();
            if (sound != null)  sound.PlaySound();
        }
        HighlightStack(stackMachines);
        return true;
    }

    private void HighlightStack(GameObject stack)
    {
        Renderer[] renderers = stack.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            foreach (Material mat in renderer.materials)
            {
                mat.EnableKeyword("_EMISSION");
                mat.SetColor("_EmissionColor", new Color(1.0f, 0.8f, 0.0f) * 0.5f); 
            }
        }
    }


}
