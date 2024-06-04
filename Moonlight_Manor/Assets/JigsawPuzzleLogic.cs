using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawPuzzleLogic : MonoBehaviour
{
    public List<Transform> pieces = new List<Transform>();
    public List<Vector3> originalPosition = new List<Vector3>();

    void Start()
    {  
        InitializePieces();
        SaveOriginalPosition();
        ScramblePieces();
    }

    void SaveOriginalPosition(){
        foreach(Transform piece in pieces){
            originalPosition.Add(piece.position);
        }
    }
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
    void InitializePieces(){
        for(int i = 0; i < 35; i++){
            pieces.Add(transform.GetChild(i));
        }
    }
}


