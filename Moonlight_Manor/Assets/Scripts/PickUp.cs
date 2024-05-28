using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    Vector3 mousePosition;
    private Vector3 GetMousePos(){
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown(){
        mousePosition = Input.mousePosition - GetMousePos();
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
