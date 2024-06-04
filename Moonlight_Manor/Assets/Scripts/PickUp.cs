using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
    private List<Transform> pieces;
    private List<Vector3> OgPos;
    private Transform pickedUpPiece = null;
    Vector3 mousePosition;
    float width;

    void Start(){
        JigsawPuzzleLogic jigsaw = FindObjectOfType<JigsawPuzzleLogic>();
        pieces = jigsaw.pieces;
        OgPos = jigsaw.originalPosition;
    }

    private Vector3 GetMousePos(){
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown(){
        mousePosition = Input.mousePosition - GetMousePos();
        pickedUpPiece = transform;
        Debug.Log(pickedUpPiece.name);

    }
    private void OnMouseDrag(){
        // Get the current mouse position in screen space
        Vector3 currentMousePosition = Input.mousePosition - mousePosition;
        // Convert the screen space position to world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(currentMousePosition);
        
        // Only take x and z coordinates, keep y the same as the object's current position
        transform.position = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);
    }

    private void OnMouseUp(){
        snapToPosition();
    }

    private void snapToPosition(){
        int pieceIndex = pieces.IndexOf(pickedUpPiece);

        width = GetPieceWidth(pickedUpPiece);

        Vector3 targetPosition = OgPos[pieceIndex];

        if(Vector3.Distance(pickedUpPiece.position,targetPosition) < width/2){
            pickedUpPiece.position = targetPosition;
            pickedUpPiece.GetComponent<MeshCollider>().enabled = false;

        }
        
        
    }

    private float GetPieceWidth(Transform piece){
        Renderer pieceRender = piece.GetComponent<Renderer>();
        return pieceRender.bounds.size.x;
    }

}