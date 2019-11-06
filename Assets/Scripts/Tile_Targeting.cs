using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile_Targeting : MonoBehaviour
{
    public Tile tileHighlighter; //Tile used to mark targeted Tile
    public Tilemap tilemap;
    public Tile targetedTile; //saves tile "under" tileHighlighter, is the targeted tile
    float playerRot;
    Vector3Int playerPos;
    Vector3Int targetLoc; //Coordinates to be targeted
    Vector3Int targetLocOld; //Coordinates of last targeted Tile
    Player_Movement movementscript;
    [SerializeField] GameObject player;

    void Start()
    {
        movementscript = player.GetComponent<Player_Movement>();
        playerRot = movementscript.rotation;
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
        playerRot = movementscript.rotation;
        if (Mathf.Round(playerRot) == 0)
        {
            targetLoc = new Vector3Int(playerPos.x, playerPos.y + 1, 0);
        }
        if (Mathf.Round(playerRot) == -90)
        {
            targetLoc = new Vector3Int(playerPos.x + 1, playerPos.y, 0);
        }
        if (Mathf.Round(playerRot) == 180)
        {
            targetLoc = new Vector3Int(playerPos.x, playerPos.y - 1, 0);
        }
        if (Mathf.Round(playerRot) == 90)
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
