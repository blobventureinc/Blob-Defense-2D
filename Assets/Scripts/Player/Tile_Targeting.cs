using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile_Targeting : MonoBehaviour {
    public Tile tileHighlighter; //Tile used to mark targeted Tile
    [SerializeField] private Tilemap tilemap = null;
    public Tile targetedTile; //saves tile "under" tileHighlighter, is the targeted tile
    private Vector3Int playerPos;
    private Vector3Int targetLoc; //Coordinates to be targeted
    private Vector3Int targetLocOld; //Coordinates of last targeted Tile, to restore it if highlighter moves
    [SerializeField] private Player_Movement movementScript = null;

    private void Update() {
        
    }
    void Start() {
      
        
    }

    private void FixedUpdate() {
        if (movementScript.isMovingByKey) {
            playerPos = tilemap.WorldToCell(transform.position);
            targetLoc = new Vector3Int(playerPos.x + Mathf.RoundToInt(movementScript.lastVelocity.normalized.x) , playerPos.y + Mathf.RoundToInt(movementScript.lastVelocity.normalized.y), 0);
            if (targetLoc != targetLocOld) {
                if (targetedTile != null) {
                    tilemap.SetTile(targetLocOld, targetedTile); //restore old tile
                }
                targetedTile = (Tile)tilemap.GetTile(targetLoc);
                tilemap.SetTile(targetLoc, tileHighlighter);  // set the new tile              
                targetLocOld = targetLoc; // save the new position for restoring next frame
            }
            tilemap.SetTile(targetLoc, tileHighlighter);
        }
    }
    public void MouseTargetTile(Vector3 clickPos) {
        targetLoc = new Vector3Int((int)clickPos.x, (int)clickPos.y, 0);
        if (clickPos.x < 0) { targetLoc.x--; }
        if (clickPos.y < 0) { targetLoc.y--; }
        if (targetLoc != targetLocOld) {
            if (targetedTile != null) {
                tilemap.SetTile(targetLocOld, targetedTile); //restore old tile
            }
            targetedTile = (Tile)tilemap.GetTile(targetLoc);
            tilemap.SetTile(targetLoc, tileHighlighter); // set the new tile           
            targetLocOld = targetLoc; // save the new position for restoring next frame
        }
    }
    public Vector3Int gettargetLoc() {
        return targetLoc;
    }
}
