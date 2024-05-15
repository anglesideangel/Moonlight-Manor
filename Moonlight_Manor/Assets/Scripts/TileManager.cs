using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class TileManager : MonoBehaviour
{
    public TMP_Text text;

    private List<Tile>[] correctTiles;
    private List<Tile>[] correctTilesFound;

    public List<bool> foundStartTile = new List<bool> { false, false };
    public List<bool> puzzleCompleted = new List<bool> { false, false };

    public GameObject door;
    // to be sure that it init the list before Tiles.cs calls AddCorrectTile
    // and try to access to lists 
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
        text.gameObject.SetActive(false);

    }

    
    public void AddCorrectTile(Tile tile, int index)
    {
        correctTiles[index].Add(tile);
    }
    public void AddCorrectTileFound(Tile tile, int index)
    {
        correctTilesFound[index].Add(tile);
        CheckPuzzleCompleted(index);
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

    private void CheckPuzzleCompleted(int index)
    {
        
        if (correctTiles[index].Count != correctTilesFound[index].Count)
        {
            return;
            
        }
       
        
        foreach (Tile tile in correctTiles[index])
        { 
            // no order
            if (!correctTilesFound[index].Contains(tile))
            {
                return; 
            }
        }
        
        text.gameObject.SetActive(true);
        puzzleCompleted[index] = true;
        door.GetComponent<DoorNewSceneController>().OpenDoor();
    } 

    public IEnumerator RevealPath()
    {
        for (int index = 0; index < 2 ; index++){
            foreach (Tile tile in correctTiles[index])
            { 
                if (tile.GetComponent<Renderer>().material.color != Color.green){
                    tile.ChangeColor(index);
                }
            }
        }
        
        yield return new WaitForSeconds(2);
        for (int index = 0; index <2 ; index++){
            foreach (Tile tile in correctTiles[index])
            { 
                tile.ResetColor();
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
