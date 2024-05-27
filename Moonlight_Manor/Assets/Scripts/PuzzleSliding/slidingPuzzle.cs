using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slidingPuzzle : MonoBehaviour
{
    public static slidingPuzzle Instance;

    public List<PuzzlePiece> puzzlePieces;
    public Vector3 emptyPosition;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        emptyPosition = GameObject.Find("EmptySpace").transform.position;
        ShufflePuzzle();
    }

    void ShufflePuzzle()
    {
        List<Vector3> positions = new List<Vector3>();
        foreach (PuzzlePiece piece in puzzlePieces)
        {
            positions.Add(piece.transform.position);
        }

        for (int i = positions.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Vector3 temp = positions[i];
            positions[i] = positions[randomIndex];
            positions[randomIndex] = temp;
        }

        for (int i = 0; i < puzzlePieces.Count; i++)
        {
            puzzlePieces[i].transform.position = positions[i];
            if (positions[i] == emptyPosition)
            {
                emptyPosition = puzzlePieces[i].transform.position;
            }
        }
    }

    public void MovePiece(PuzzlePiece piece)
    {
        Vector3 currentPosition = piece.transform.position;
        float distance = Vector3.Distance(currentPosition, emptyPosition);
        if (10 < distance && distance < 11)
        {
            piece.targetPosition = emptyPosition;
            piece.isMoving = true;

            emptyPosition = currentPosition;
        }
    }
}
