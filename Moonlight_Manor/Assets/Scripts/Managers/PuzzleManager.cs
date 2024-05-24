using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour
{
    // Start is called before the first frame update
    private bool[] completedPuzzles = { false, false, false, false, false, false, false }; // 7 because 1st clue is in the lobby
    public GameObject[] hintsArray = new GameObject[7]; // 7 because 1st clue is in the lobby
    public GameObject doorUnlockedMessage;
    public GameObject endGameMessage;
    public static PuzzleManager Instance { get; private set; }
    public Button[] roomsButtons = new Button[7];

    public GameObject hintToDisplay;
    public Sprite closeImage; // temp solution ->find a better way
    public bool debugMode;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
        doorUnlockedMessage.SetActive(false);
        foreach (GameObject message in hintsArray)
        {
            message.SetActive(false);
        
        }
        foreach (Button button in roomsButtons)
        {
            button.interactable =false;
        }
        
    }
    void Update(){
        if (debugMode)
        {
            
            for (int i = 0; i < 7; i++)
            {
                DoorManager.Instance.UnlockNextDoor(i + 1);
            }
        }
    }
    void CheckAllPuzzlesCompleted()
    {
        if (AllPuzzleCompleted()){
            endGameMessage.SetActive(false);
        }
    }

    public void PuzzleCompleted(int order)
    {
        completedPuzzles[order] = true;
        DoorManager.Instance.UnlockNextDoor(order+1);
        StartCoroutine(Activate(order,3f));
        // griser case 
        
        Button button = roomsButtons[order].GetComponent<Button>();
        ColorBlock colors = button.colors;
        colors.disabledColor = new Color(0.64f,0.62f,0.76f,1);
        button.colors = colors;
        CheckAllPuzzlesCompleted();
    }

    private IEnumerator Activate(int order, float delay)
    {
        if (doorUnlockedMessage == null)
        {
            Debug.LogWarning("doorUnlockedMessage is null");
            yield break;
        }

        if (order != 0)
        {
            UIManager.Instance.DisableButton();
        }
        if (order !=0) UIManager.Instance.DisableButton();
        yield return new WaitForSeconds(1);
        doorUnlockedMessage.SetActive(true);
        yield return new WaitForSeconds(delay);
        doorUnlockedMessage.SetActive(false);
    }

    public bool AllPuzzleCompleted(){
        foreach (bool b in completedPuzzles)
        {
            if (!b) return false;
        }
        return true;
    }

    public void DisplayHint(int order){
        if (hintsArray[order] != null && order !=0)
        { // temporary fix, to change
            hintToDisplay = hintsArray[order]; //.SetActive(true)
            UIManager.Instance.UpdateHintBox(hintToDisplay);
        }
        
    }

    public void DisplayFirstHint(){
        if (hintsArray[0] != null){ // temporary fix, to change
            hintToDisplay = hintsArray[0]; //.SetActive(true)
            //UIManager.Instance.UpdateHintBox(hintToDisplay);
            hintToDisplay.SetActive(true);
            // hintToDisplay = hintsArray[0]; //.SetActive(true)
            // UIManager.Instance.UpdateHintBox(hintToDisplay);
            // hintToDisplay.SetActive(true);
            // UIManager.Instance.ChangeImage(closeImage);
            // UIManager.Instance.closeButton = true;
            // PuzzleCompleted(0);
        }
    }

    public void HideFirstHint(){
        if (hintsArray[0] != null){ // temporary fix, to change
            hintToDisplay.SetActive(false);
            PuzzleCompleted(0);
        }
    }
}
