using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LockController : MonoBehaviour
{
    // Start is called before the first frame update

    private int[] result;
    private int[] correctResult;
    public TMP_Text textCorrect;
    public TMP_Text textFalse;
    public GameObject doorObject4;

   
    void Start()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += OnSceneLoaded;
        result = new int[] { 0, 0, 0};
        correctResult = new int[] {5,8,7};
        // correctResult = new int[] {1,0,0};
        Rotate.Rotated += UpdateResults;
        textCorrect.gameObject.SetActive(false);
        textFalse.gameObject.SetActive(false);
        if (doorObject4 != null) {
            doorObject4 = GameObject.Find("DoorObject (4)");
            Debug.Log(doorObject4 != null);
        }

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Main")
            { SceneManager.sceneLoaded -= OnSceneLoaded; }
    }

    public void UpdateResults(string wheelName, int number)
    {
        textFalse.gameObject.SetActive(false);
        if (wheelName == "wheel1") result[0] = number;
        else if (wheelName == "wheel2") result[1] = number;
        else if (wheelName == "wheel3") result[2] = number;

    }
    
    public void CheckResults()
    {
        if ((result[0] == correctResult[0]) && (result[1] == correctResult[1]) && (result[2] == correctResult[2])) {
            textCorrect.gameObject.SetActive(true);
            if (doorObject4 != null) {
                doorObject4.SetActive(true);
                doorObject4.GetComponent<DoorController>().isLocked = false;;
            } else {Debug.LogError("DoorObject (4) not found in Main scene!");}

        } else {
            textFalse.gameObject.SetActive(true);
        }
    }

    private void OnDestroy(){
        Rotate.Rotated -= UpdateResults;
    }
   
    
}
