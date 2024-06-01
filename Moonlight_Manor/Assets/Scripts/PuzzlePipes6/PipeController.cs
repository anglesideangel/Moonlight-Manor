using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PipeController : MonoBehaviour
{
    private int[] result;
    private int[] correctResult;
    public TMP_Text textCorrect;
    public TMP_Text textFalse;
    public GameObject Pipes;
   
    public Material[] materials;
    Renderer rend;

    void Start()
    {   
        rend = GetComponent<Renderer>();
        rend.enabled = true;     
        result = new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        correctResult = new int[] {2, 1, 1, 2, 2, 2, 1, 3, 0, 1, 0, 0, 2, 3, 2, 1, 0, 2, 3, 0, 1, 0, 3, 1, 3};
        pipeRotate.Rotated += UpdateResults;
        textCorrect.gameObject.SetActive(false);
        textFalse.gameObject.SetActive(false);
     
        //UIManager.Instance.HideHint();
    }

    public void UpdateResults(string tile, int number)
    {
        textCorrect.gameObject.SetActive(false);
        textFalse.gameObject.SetActive(false);
        int index = int.Parse(tile) - 1; // Convert tile string to zero-based index
        if (index >= 0 && index < result.Length)
        {
            result[index] = number;
        }
    }
   
    public void CheckResults()
    {
        bool allCorrect = true;
        for (int i = 0; i < 25; i++) {
            if (result[i] != correctResult[i]) {
                allCorrect = false;
                break;
            }
        }
        if (allCorrect) {
            for (int i = 0; i < 27; i++)
        {
            // Get the Renderer component of the current GameObject
            Renderer renderer = Pipes.transform.GetChild(i).GetComponent<Renderer>();

            // Check if a Renderer component is attached
            if (renderer != null)
            {
                // Assign the material index based on your conditions
                int materialIndex;
                if (i == 0 || i == 20 || i == 24)
                {
                    materialIndex = 0;
                }
                else if (i == 8 || i == 9 || i == 15 || i == 16 || i == 23 || i == 25 || i == 26)
                {
                    materialIndex = 1;
                }
                else if (i == 11)
                {
                    materialIndex = 2;
                }
                else if (i == 3 || i == 6 || i == 10 || i == 13 || i == 14 || i == 17 || i == 22)
                {
                    materialIndex = 3;
                }
                else
                {
                    materialIndex = 4;
                }
                // Set the material of the Renderer component
                renderer.material = materials[materialIndex];
            }
        }
        textCorrect.gameObject.SetActive(true);
    }
        else {
            StartCoroutine(ShowErrorForFewSeconds());
        }
    }
            //PuzzleManager.Instance.PuzzleCompleted(3);

    private System.Collections.IEnumerator ShowErrorForFewSeconds()
    {
        textFalse.gameObject.SetActive(true);
        yield return new WaitForSeconds(2f); // Adjust the duration as needed
        textFalse.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        pipeRotate.Rotated -= UpdateResults;
    }
}
