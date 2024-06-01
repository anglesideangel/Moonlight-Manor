using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SlidingPuzzle : MonoBehaviour
{
    public static SlidingPuzzle Instance;

    public List<PuzzlePiece> puzzlePieces;
    public Vector3 emptyPosition;
    public List<Vector3> positions = new List<Vector3>();
    public List<Vector3> initialPositions = new List<Vector3>();
    public List<int> numbers = new List<int>();
    public TMP_Text textSolved;
    public GameObject Tiles;

    void Awake()
    {
        Instance = this;
        textSolved.gameObject.SetActive(false);

    }

    void Start()
    {
        textSolved.gameObject.SetActive(false);
        emptyPosition = GameObject.Find("EmptySpace").transform.position;
        ShufflePuzzle();
    }

    public void index(Vector3 position)
    {
        int number = 0;
        foreach (PuzzlePiece piece in puzzlePieces)
        {
            if (piece.gameObject.activeInHierarchy && piece.transform.position == position)
            {
                number = puzzlePieces.IndexOf(piece) + 1; // Add 1 to make the numbers start from 1
                break;
            }
        }
        numbers.Add(number);
    }
 
    void ShufflePuzzle()
    {
        textSolved.gameObject.SetActive(false);
        // Clear lists
        positions.Clear();
        initialPositions.Clear();
        numbers.Clear();

        foreach (PuzzlePiece piece in puzzlePieces)
        {
            positions.Add(piece.transform.position);
            initialPositions.Add(piece.transform.position);
        }

        for (int i = positions.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Vector3 temp = positions[i];
            positions[i] = positions[randomIndex];
            positions[randomIndex] = temp;
        }

        // Update the numbers list with the shuffled positions
        foreach (Vector3 position in positions)
        {
            index(position);
        }

        if (!IsSolvable(numbers))
        {
            textSolved.gameObject.SetActive(false);
            // Reshuffle until a solvable state is found
            ShufflePuzzle();
            return;
        }
        else {
            // Apply shuffled positions to puzzle pieces
            for (int i = 0; i < puzzlePieces.Count; i++)
            {
                puzzlePieces[i].transform.position = positions[i];
            }
        }
    }

    public void MovePiece(PuzzlePiece piece)
    {
        textSolved.gameObject.SetActive(false);
        // Check if the puzzle is solved before each move
            if (IsSolved(initialPositions))
            {
                textSolved.gameObject.SetActive(true);
                return;
            }
        Vector3 currentPosition = piece.transform.position;
        float distance = Vector3.Distance(currentPosition, emptyPosition);
        if (23 < distance && distance < 24 && !IsSolved(initialPositions))
        {
            piece.targetPosition = emptyPosition;
            emptyPosition = currentPosition;

            piece.isMoving = true;

            // Check if the puzzle is solved after each move
            if (IsSolved(initialPositions))
            {
                textSolved.gameObject.SetActive(true);
                return;
            }
        }
    }
 
    bool IsSolvable(List<int> numbers)
    {
        textSolved.gameObject.SetActive(false);
        // Count inversions
        int inversions = 0;
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            for (int j = i + 1; j < numbers.Count; j++)
            {
                // Check if the numbers are out of order and not equal to 0
                if (numbers[i] != 0 && numbers[j] != 0 && numbers[i] > numbers[j])
                {
                    inversions++;
                }
            }
        }
        // Check if the number of inversions is even
        return inversions % 2 == 0;
    }
    
    bool IsSolved(List<Vector3> initialPositions)
    {
        textSolved.gameObject.SetActive(false);
        for (int i = 0; i < puzzlePieces.Count; i++)
        {
            if (puzzlePieces[i].transform.position != initialPositions[i])
            {
                return false;
            }
        }
        // Puzzle is solved
        return true;
    }
}
