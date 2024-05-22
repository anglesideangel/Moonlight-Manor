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

   
    void Start()
    {
        result = new int[] { 0, 0, 0};
        correctResult = new int[] {5,8,7};
        Rotate.Rotated += UpdateResults;
        textCorrect.gameObject.SetActive(false);
        textFalse.gameObject.SetActive(false);

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
        } else {
            textFalse.gameObject.SetActive(true);
        }
    }

    private void OnDestroy(){
        Rotate.Rotated -= UpdateResults;
    }
   
    
}
