using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class TileManager : MonoBehaviour
{
    public Canvas[] canvas = new Canvas[2];

    private List<Tile>[] correctTiles;
    private List<Tile>[] correctTilesFound;

    public List<bool> foundStartTile = new List<bool> { false, false };
    public List<bool> puzzleCompleted = new List<bool> { false, false };

    public GameObject door;
    // to be sure that it init the list before Tiles.cs calls AddCorrectTile
    // and try to access to lists 

    public GameObject soundEnd;

    void Awake()
    {
        correctTiles = new List<Tile>[2]; 
        correctTiles[0] = new List<Tile>(); 
        correctTiles[1] = new List<Tile>(); 
        correctTilesFound = new List<Tile>[2]; 
        correctTilesFound[0] = new List<Tile>(); 
        correctTilesFound[1] = new List<Tile>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (Canvas canva in canvas)
        {
            if (canva != null) canva.gameObject.SetActive(false);
        }

    }

    
    public void AddCorrectTile(Tile tile, int index)
    {
        correctTiles[index].Add(tile);
    }
    public void AddCorrectTileFound(Tile tile, int index)
    {
        correctTilesFound[index].Add(tile);
        CheckPathCompleted(index);
    }

    
    public void ResetTilePuzzle(int index)
    {
        foreach (Tile tile in correctTilesFound[index])
        {
            tile.ResetColor();
        }
        correctTilesFound[index].Clear();
        foundStartTile[index] = false;
    
    }

   private IEnumerator DisplayMessage(Canvas canvas, float duration)
    {
        canvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        canvas.gameObject.SetActive(false);
        if (CheckPuzzleCompleted())
        {
            PuzzleManager.Instance.PuzzleCompleted(2);
        }
    }

    private void CheckPathCompleted(int index)
    {
        if (correctTiles[index].Count != correctTilesFound[index].Count)
        {
            return;
        }

        foreach (Tile tile in correctTiles[index])
        { 
            if (!correctTilesFound[index].Contains(tile))
            {
                return; 
            }
        }
        if (soundEnd != null)
        {
            SoundEndLaundryController sound = soundEnd.GetComponent<SoundEndLaundryController>();
            if (sound != null)  sound.PlaySound();
        }

        StartCoroutine(DisplayMessage(canvas[index], 2.0f)); 
        puzzleCompleted[index] = true;
        // door.GetComponent<DoorNewSceneController>().OpenDoor();
        CheckPuzzleCompleted();
    }
    private bool CheckPuzzleCompleted()
    {
        foreach (bool b in puzzleCompleted)
        { 
            if (b == false)
            {
                return false; 
            }
        }
        return true;
    }


    public IEnumerator RevealPath()
    {
        for (int index = 0; index < 2 ; index++){
            foreach (Tile tile in correctTiles[index])
            { 
                //if (tile.GetComponent<Renderer>().material.color != Color.green){
                    tile.ChangeColor(index);
               // }
            }
        }
        
        yield return new WaitForSeconds(2);
        for (int index = 0; index <2 ; index++){
            foreach (Tile tile in correctTiles[index])
            { 
                if (!correctTilesFound[index].Contains(tile))
            {
                tile.ResetColor();
            }
               
            }
        }



    }
    public bool IsNextTileInPath(Tile tile, int index)
    {
        if (index == 0){
            int length = correctTilesFound[index].Count;
            int prevOrder = correctTilesFound[index][length - 1].order1;
            return tile.order1 == prevOrder + 1;
        }
        
        else if (index ==1){
            int length = correctTilesFound[index].Count;
            int prevOrder = correctTilesFound[index][length - 1].order2;
            return tile.order2 == prevOrder + 1;
        }
        return false;
    }
    
}
