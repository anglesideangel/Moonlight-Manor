using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public GameObject hintBox;
    public Sprite closeImage;
    public Sprite openImage;

    public bool closeButton = false;
    private Button btn;
    public static UIManager Instance { get; private set; }
    public GameObject info;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        btn = GetComponent<Button>();
       
        if (btn != null)
        {
            btn.onClick.AddListener(TaskOnClick);
            Image buttonImage = GetComponent<Image>();
            if (buttonImage != null && openImage != null)
            {
                buttonImage.sprite = openImage;
            }
            btn.interactable = false;
            
        }
        else
        {
            Debug.LogError("Button component not found!");
        }
    }
    void Update(){
       
    }
    
    public void ChangeImage(Sprite newSprite)
    {
        if (newSprite != null)
        {
            Image buttonImage = GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.sprite = newSprite;
            }
        }
    }

    void TaskOnClick()
    {
        if (!closeButton) // Open button
        {
            ChangeImage(closeImage);
            hintBox.SetActive(true);
            closeButton = true;
        }
        else // Close button
        {
            HideHint();
        }
    }

    public void HideHint(){
        if (closeButton){
            ChangeImage(openImage);
            hintBox.SetActive(false);
            closeButton = false;
        }
    }

    public void UpdateHintBox(GameObject newHint)
    {
        if (newHint != null)
        {
            btn.interactable = true;
            hintBox = newHint;
        }
    }
    public void DisableButton(){
        btn.interactable = false;
    }

    public void DisplayInfo(){
        info.SetActive(true);
    }
    public void HideInfo(){
        info.SetActive(false);
    }


   
}