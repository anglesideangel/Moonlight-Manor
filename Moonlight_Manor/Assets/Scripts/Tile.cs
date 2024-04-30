using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    public bool isCorrectTile = false;
    public bool isStartingTile = false;
    public int order = 0;
   
   // Start is called before the first frame update
    void Start()
    {
        if (isCorrectTile)
        {
            TileManager.Instance.AddCorrectTile(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            if (isStartingTile){
                TileManager.Instance.foundStartingTile =  true;
                GetComponent<Renderer>().material.color = Color.green;
                TileManager.Instance.AddCorrectTileFound(this);
                
            }
            if (isCorrectTile && TileManager.Instance.foundStartingTile)
            {
                if (TileManager.Instance.IsNextTileInPath(this))
                {
                    GetComponent<Renderer>().material.color = Color.green;
                    TileManager.Instance.AddCorrectTileFound(this);
                }

            }
            else
            {
                TileManager.Instance.Reset();
            }
        }
        
    }
    public void ResetColor()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
