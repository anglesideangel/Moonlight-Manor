using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawPuzzleLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScramblePieces();
    }

    // Update is called once per frame
    void ScramblePieces()
    {
        Transform[] pieces = new Transform[transform.childCount - 1];
        for(int i = 0; i < transform.childCount - 1; i++){
            pieces[i] = transform.GetChild(i);
        }

        for(int i = pieces.Length - 2; i > 0; i--){
            int j = Random.Range(0,i+1);
            Vector3 temp = pieces[i].position;
            pieces[i].position = pieces[j].position;
            pieces[j].position = temp;
        }
    }
}
