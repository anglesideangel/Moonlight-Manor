using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class TileManager : MonoBehaviour
{
    public static TileManager Instance;
    public TMP_Text text;

    private List<Tile> correctTiles = new List<Tile>();
    private List<Tile> correctTilesFound = new List<Tile>();
    public bool foundStartingTile= false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(false);
    }

    
    public void AddCorrectTile(Tile tile)
    {
        correctTiles.Add(tile);
    }
    public void AddCorrectTileFound(Tile tile)
    {
        correctTilesFound.Add(tile);
        CheckPuzzleCompleted();
    }

    
    public void Reset()
    {
        foreach (Tile tile in correctTilesFound)
        {
            tile.ResetColor();
        }
        correctTilesFound.Clear();
        foundStartingTile = false;
    
    }

    private void CheckPuzzleCompleted()
    {
        
        if (correctTiles.Count != correctTilesFound.Count)
        {
            Debug.Log("yee");
            return;
            
        }
        foreach (Tile tile in correctTilesFound)
        {
            Debug.Log(tile.gameObject.name);
        }
        
        foreach (Tile tile in correctTiles)
        { 
            // no order
            if (!correctTilesFound.Contains(tile))
            {
                Debug.Log("espresso");
                return; 
            }
        }
        
        Debug.Log("yay");
        text.gameObject.SetActive(true);
    } 


    public bool IsNextTileInPath(Tile tile)
    {
        int length = correctTilesFound.Count;
        int prevOrder = correctTilesFound[length - 1].order;
        return tile.order == prevOrder + 1;
    }
}
