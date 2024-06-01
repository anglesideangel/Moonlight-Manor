using UnityEngine;

public class SoundEndLaundryController : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    // Public method to play the audio clip
    public void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}