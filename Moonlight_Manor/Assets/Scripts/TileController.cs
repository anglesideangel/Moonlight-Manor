using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    
   
   // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   /* private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("hola");
        if (collision.gameObject.CompareTag("Tile")) // Assuming the player has the "Player" tag
        {
            Debug.Log("heel");
            Tile tile = collision.gameObject.GetComponent<Tile>();

            if (tile != null)
            {
                if (tile.isCorrectTile)
                {
                    Debug.Log("heyyy");
                    // Change color of correct tile
                    //tile.material.color = Color.green;
                }
                else
                {
                    // Reset path
                   // TileManager.Instance.ResetPath();
                }
            }
        }
    }*/
}
