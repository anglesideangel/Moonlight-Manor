using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : NetworkBehaviour
{
    // Start is called before the first frame update
    private NetworkVariable<int> completedPuzzles = new NetworkVariable<int>(0); // 0b00000000, rightmost is puzzle 0, then 1, etc.
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

    public override void OnNetworkSpawn(){
        completedPuzzles.OnValueChanged += OnPuzzleCompleted;
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

    void OnPuzzleCompleted(int prev, int cur){
        int dif = cur - prev; //only 1 bit should be enabled, the position of it is our order
        int order = 0;
        while (dif > 1)
        {
            dif >>= 1;
            order++;
        }
        //order is now the order of our changed puzzle

        DoorManager.Instance.UnlockNextDoor(order+1);
        StartCoroutine(Activate(order,3f));
        // griser case 
        
        Button button = roomsButtons[order].GetComponent<Button>();
        ColorBlock colors = button.colors;
        colors.disabledColor = new Color(0.64f,0.62f,0.76f,1);
        button.colors = colors;
        CheckAllPuzzlesCompleted();
    }

    public void PuzzleCompleted(int order)
    {
        CompletePuzzleServerRpc(order);   
    }

    [Rpc(SendTo.Server)]
    void CompletePuzzleServerRpc(int order){
        completedPuzzles.Value |= 1 << order;
    }

    bool GetPuzzleCompleted(int order){
        return (completedPuzzles.Value & (1 << order-1)) != 0;
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
        DoorSoundPlayer.Instance.Play();
        // yield return new WaitForSeconds(1);
        // doorUnlockedMessage.SetActive(true);
        // yield return new WaitForSeconds(delay);
        // doorUnlockedMessage.SetActive(false);
        FadeAway fadeAway = doorUnlockedMessage.GetComponent<FadeAway>();
        if (fadeAway != null)
        {
            fadeAway.ShowMessage();
            yield return new WaitForSeconds(fadeAway.fadeInTime + fadeAway.visibleTime + fadeAway.fadeOutTime);
        }
        else
        {
            doorUnlockedMessage.SetActive(true);
            yield return new WaitForSeconds(delay);
            doorUnlockedMessage.SetActive(false);
        }
    }

    public bool AllPuzzleCompleted(){
        for(int i = 0; i < 7; i++)
        {
            if (!GetPuzzleCompleted(i)) return false;
        }
        return true;
    }

    public void DisplayHint(int order){
        if (order < 7 && hintsArray[order] != null && order !=0)
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
