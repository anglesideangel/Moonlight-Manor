using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public int number; // Number assigned to the puzzle piece
    public Vector3 targetPosition; // Target position when moving the puzzle piece
    public bool isMoving; // Flag to track if the puzzle piece is currently moving
    public float moveSpeed = 50f;

    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            if (transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
    }

    void OnMouseDown()
    {
        if (!isMoving && SlidingPuzzle.Instance != null)
        {
            SlidingPuzzle.Instance.MovePiece(this);
        }
    }
}