using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile_Targeting : MonoBehaviour
{
    public Tile tileHighlighter; //Tile used to mark targeted Tile
    [SerializeField] Tilemap tilemap;
    public Tile targetedTile; //saves tile "under" tileHighlighter, is the targeted tile
    int playerFacing;
    Vector3Int playerPos;
    Vector3Int targetLoc; //Coordinates to be targeted
    Vector3Int targetLocOld; //Coordinates of last targeted Tile
    Player_Movement movementscript;
    [SerializeField] GameObject player;

    void Start()
    {
        movementscript = player.GetComponent<Player_Movement>();
        playerFacing = movementscript.facing;
        targetLocOld = targetLoc;
    }
    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
    private void FixedUpdate()
    {
        
        Vector3Int playerPos = tilemap.WorldToCell(transform.position);
        playerFacing = movementscript.facing;
        if (Mathf.Round(playerFacing) == 1)
        {
            targetLoc = new Vector3Int(playerPos.x, playerPos.y + 1, 0);
        }
        if (Mathf.Round(playerFacing) == 2)
        {
            targetLoc = new Vector3Int(playerPos.x + 1, playerPos.y, 0);
        }
        if (Mathf.Round(playerFacing) == 3)
        {
            targetLoc = new Vector3Int(playerPos.x, playerPos.y - 1, 0);
        }
        if (Mathf.Round(playerFacing) == 4)
        {
            targetLoc = new Vector3Int(playerPos.x - 1, playerPos.y, 0);
        }
        if (targetLoc != targetLocOld)
        {
            if(targetedTile != null)
                {
                    tilemap.SetTile(targetLocOld, targetedTile);
                }        
            targetedTile = (Tile)tilemap.GetTile(targetLoc);
            // set the new tile
            tilemap.SetTile(targetLoc, tileHighlighter);
            // save the new position for next frame
            targetLocOld = targetLoc;
        }                
    }
}
