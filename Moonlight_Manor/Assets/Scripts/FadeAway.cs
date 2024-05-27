using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro;
using UnityEngine.UI;

public class FadeAway : MonoBehaviour
{
    public float fadeInTime = 1f;
    public float visibleTime = 1f;
    public float fadeOutTime = 1f;

    private RawImage image;
    private TMP_Text text;

    private float currentTime = 0f;
    private enum FadeState { None, FadingIn, Visible, FadingOut }
    private FadeState fadeState = FadeState.None;

    void Start()
    {
        // Find the Image component on the GameObject
        image = GetComponentInChildren<RawImage>();
        // Find the TMP_Text component in the children of this GameObject
        text = GetComponentInChildren<TMP_Text>();

        if (image == null || text == null)
        {
            Debug.LogError("Image and/or TMP_Text component not found");
            return;
        }

        SetAlpha(0f); // Ensure the text starts invisible
    }

    void Update()
    {
        if (fadeState == FadeState.FadingIn)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= fadeInTime)
            {
                currentTime = fadeInTime;
                fadeState = FadeState.Visible;
                StartCoroutine(WaitThenFadeOut());
            }
            SetAlpha(currentTime / fadeInTime);
        }
        else if (fadeState == FadeState.FadingOut)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                fadeState = FadeState.None;
                gameObject.SetActive(false); // Optionally deactivate the GameObject
            }
            SetAlpha(currentTime / fadeOutTime);
        }
    }

    public void ShowMessage()
    {
        if (image == null || text == null)
        {
            Debug.LogError("Image and/or TMP_Text component not set");
            return;
        }

        currentTime = 0f;
        fadeState = FadeState.FadingIn;
        gameObject.SetActive(true); // Ensure the GameObject is active
    }

    private void SetAlpha(float alpha)
    {
        if (image != null)
        {
            Color imageColor = image.color;
            image.color = new Color(imageColor.r, imageColor.g, imageColor.b, alpha);
        }
        
        if (text != null)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        }
    }

    private IEnumerator WaitThenFadeOut()
    {
        yield return new WaitForSeconds(visibleTime);
        fadeState = FadeState.FadingOut;
    }
}
