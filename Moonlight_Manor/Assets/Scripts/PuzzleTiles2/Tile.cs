using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileManager manager;
    //public List<bool> isCorrectTileList = new List<bool> { false, false };
 
    public bool[] isStartTileList = new bool[2];
    public bool[] isCorrectTileList = new bool[2];
    public bool isEntringTile;
    public int order1;
    public int order2;
   

   // Start is called before the first frame update
    void Start()
    {
        if (isCorrectTileList[0]) manager.AddCorrectTile(this, 0);
        if (isCorrectTileList[1]) manager.AddCorrectTile(this, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int index = 0;
        if (other.CompareTag("Player")){
            //bug to fix
            if (other.transform.parent == PlayerManager.Instance.Player1 ) index = 0;
            if (other.transform.parent == PlayerManager.Instance.Player2 ) index = 1;
            Debug.Log(index);
            if (!manager.puzzleCompleted[index]){
                if (isEntringTile){
                    StartCoroutine(manager.RevealPath());

                }
                if (isStartTileList[index]){
                    manager.foundStartTile[index] =  true;
                    ChangeColor(index);
                    manager.AddCorrectTileFound(this, index);
                    
                }

                if (isCorrectTileList[index] && manager.foundStartTile[index])
                {
                    if (manager.IsNextTileInPath(this, index))
                    {
                        ChangeColor(index);
                        manager.AddCorrectTileFound(this, index); 
                    }

                }
                else
                {
                    if (manager.foundStartTile[index]){
                        StartCoroutine(TeleportCharacter(other));
                    }
                    manager.ResetTilePuzzle(index);
                }
            }
        }
        
            
        }
        
    

    public IEnumerator TeleportCharacter(Collider other)
    {
        GameObject character = other.transform.parent.gameObject;

        FPSController script = other.GetComponent<FPSController>();
                
        script.enabled = false;
        character.transform.position = new Vector3(0.12f, 1.98f, 25.91f);
                
        yield return new WaitForSeconds(0.1f);
        script.enabled = true;

    }
    public void ResetColor()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }


    public void ChangeColor(int index)
    {
        if (index == 0) GetComponent<Renderer>().material.color = Color.green;
        if (index == 1) GetComponent<Renderer>().material.color = Color.blue;
    }

}
