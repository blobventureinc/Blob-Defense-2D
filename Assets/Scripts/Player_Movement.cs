using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] GameObject player;
    public float moveSpeedMax = 3f;
    public Rigidbody2D rb;
    public int facing;
    public bool isMovingByKey;
    public bool isMoving;
    TileBase clickedTile;
    Vector3 clickPos;
    Vector2 input;
    Vector2 velocity;
    Vector2 moveTo;
    Tile_Targeting targetingscript;

    void Start()
    {
        //not facing anything, so no tile targeted
        facing = 0;
        player = this.gameObject;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMovingByKey = false;
            facing = 0;
            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(string.Format("clickPos [X: {0} Y: {1}]", clickPos.x, clickPos.y));
            if (clickPos.x < 0) { clickPos.x--; }
            if (clickPos.y < 0) { clickPos.y--; }
            clickedTile = tilemap.GetTile(new Vector3Int((int)clickPos.x, (int)clickPos.y, 0));
        }
        if (Input.anyKeyDown && !Input.GetMouseButtonDown(0))
        {
            isMovingByKey = true;
            clickedTile = null;
        }
        if (isMovingByKey) { KeyBoardMovement(); }
        if (!isMovingByKey) { MouseMovement(); }
    }
    void FixedUpdate()
    {
        if (velocity.x != 0 || velocity.y != 0)
        {
            isMoving = true;
            //Move to Direction
            moveTo = rb.position + velocity * Time.fixedDeltaTime;
            rb.MovePosition(moveTo);
            //Determine facing
            //X-Axis
            if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.y))
            {
                if (velocity.x > 0)
                {
                    facing = 2;
                }
                else { facing = 4; }
            }
            //Y-Axis
            else
            {
                if (Mathf.Abs(velocity.x) < Mathf.Abs(velocity.y))
                {
                    if (velocity.y > 0)
                    {
                        facing = 1;
                    }
                    else { facing = 3; }
                }
            }
        }
        else { isMoving = false; }
    }
    void MouseMovement()
    {   
        
        Vector2 toClick = new Vector2(clickPos.x - rb.position.x, clickPos.y - rb.position.y); //vector from character to click
        float mag = toClick.magnitude; //length of toClick
        if (mag >= 0.2)
        {
            float div = mag / moveSpeedMax; //how many times allowed movespeed fits in length
            if (div > 1.0) //if a certain distance away
            {
                velocity = new Vector2(toClick.x / div, toClick.y / div); //set to click as velocity, shortened to respect allowed movespeed
            }
            else
            {
                velocity = toClick * div; //if close by, do weird calculations to get a tolerable movespeed while slowing down
                if (velocity.x <= 0.5 && velocity.y <= 0.5)
                {
                    velocity = new Vector2(0, 0);
                    player.GetComponent<Tile_Targeting>().MouseTargetTile(clickPos);
                }
            }
        }
        else { velocity = new Vector2(0, 0); } //when very close by, stop

    }
    void KeyBoardMovement()
    {
        //get input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        //Stop or slow down if no input
        if (input.x == 0)
        {
            if (Mathf.Abs(velocity.x) <= 0.05)
            {
                velocity.x = 0;
            }
            else { velocity.x *= (float)0.75; }
        }
        if (input.y == 0)
        {
            if (Mathf.Abs(velocity.y) <= 0.05)
            {
                velocity.y = 0;
            }
            else { velocity.y *= (float)0.75; }
        }
        //add input to velocity
        velocity += input;
        //Limit max moveSpeedMax
        if (velocity.x > moveSpeedMax)
        {
            velocity.x = moveSpeedMax;
        }
        if (velocity.x < -moveSpeedMax)
        {
            velocity.x = -moveSpeedMax;
        }
        if (velocity.y > moveSpeedMax)
        {
            velocity.y = moveSpeedMax;
        }
        if (velocity.y < -moveSpeedMax)
        {
            velocity.y = -moveSpeedMax;
        }
    }

}
