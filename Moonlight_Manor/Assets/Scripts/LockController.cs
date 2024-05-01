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
    public TMP_Text text;
    void Start()
    {
        result = new int[] { 0, 0, 0};
        correctResult = new int[] {2,2,2};
        Rotate.Rotated += CheckResults;
        text.gameObject.SetActive(false);
        
    }

    private void CheckResults(string wheelName, int number)
    {
        if (wheelName == "wheel1") result[0] = number;
        else if (wheelName == "wheel2") result[1] = number;
        else if (wheelName == "wheel3") result[2] = number;

        if ((result[0] == correctResult[0]) && (result[1] == correctResult[1]) && (result[2] == correctResult[2])) text.gameObject.SetActive(true);
    }

    private void OnDestroy(){
        Rotate.Rotated -= CheckResults;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)){
            SceneManager.LoadScene("Main");

         //   PlayerPrefs.DeleteKey("X");
         //   PlayerPrefs.DeleteKey("Y");
         //   PlayerPrefs.DeleteKey("Z");
        }
    }
    
}
