using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawPuzzleLogic : MonoBehaviour
{
    Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        //ScramblePieces();
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
    private Vector3 GetMousePos(){
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown(){
        mousePosition = Input.mousePosition - GetMousePos();
        Debug.Log(gameObject.name);

    }
    private void OnMouseDrag(){
        // Get the current mouse position in screen space
        Vector3 currentMousePosition = Input.mousePosition - mousePosition;
        // Convert the screen space position to world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(currentMousePosition);
        
        // Only take x and z coordinates, keep y the same as the object's current position
        transform.position = new Vector3(worldPosition.x, transform.position.y, worldPosition.z);
    }
}


