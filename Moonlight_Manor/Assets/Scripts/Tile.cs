using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
<<<<<<< Updated upstream
    
    public bool isCorrectTile;
    public bool isStartingTile;
    public int order;
=======
    public TileManager manager;
    public bool isCorrectTile = false;
    public bool isStartingTile = false;
    public int order = 0;
>>>>>>> Stashed changes
   
   // Start is called before the first frame update
    void Start()
    {
        if (isCorrectTile)
        {
            manager.AddCorrectTile(this);
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
                manager.foundStartingTile =  true;
                GetComponent<Renderer>().material.color = Color.green;
                manager.AddCorrectTileFound(this);
                
            }
            if (isCorrectTile && manager.foundStartingTile)
            {
                if (manager.IsNextTileInPath(this))
                {
                    GetComponent<Renderer>().material.color = Color.green;
                    manager.AddCorrectTileFound(this);
                }

            }
            else
            {
                manager.Reset();
            }
        }
        
    }
    public void ResetColor()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
