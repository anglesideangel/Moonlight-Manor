using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    public Vector3 targetPosition;
    public float moveSpeed = 50f;
    public bool isMoving = false;

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
        if (!isMoving)
        {
            slidingPuzzle.Instance.MovePiece(this);
        }
    }
}