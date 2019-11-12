using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeedMax = 3f;
    public Rigidbody2D rb;
    public int facing;
    public bool isMovingByKey;
    TileBase clickedTile;
    Vector2 input;
    Vector3 clickPos;
    Vector2 velocity;
    public Vector2 Velocity { get => velocity; set => velocity = value; }
    Vector2 moveTo;
    [SerializeField] Tilemap tilemap;

    void Start()
    {
        facing = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMovingByKey = false;
            facing = 0;
            Vector3 clickPos = tilemap.WorldToCell(Input.mousePosition);
            Debug.Log(string.Format("clickPos [X: {0} Y: {0}]", clickPos.x, clickPos.y));
            
            clickedTile = tilemap.GetTile(new Vector3Int((int)clickPos.x, (int)clickPos.y, 0));
        }
        if (Input.GetKeyDown("w"))
        {
            facing = 1;
            KeyBoardMovement();
        }
        if (Input.GetKeyDown("d"))
        {
            facing = 2;
            KeyBoardMovement();
        }
        if (Input.GetKeyDown("s"))
        {
            facing = 3;
            KeyBoardMovement();
        }
        if (Input.GetKeyDown("a"))
        {
            facing = 4;
            KeyBoardMovement();
        }
        if(isMovingByKey)
        {
            clickedTile = null;
            KeyBoardMovement();
        }
        if(!isMovingByKey)
        {
            MouseMovement();
        }
    }
    void FixedUpdate()
    {
        
        if(velocity.x != 0 || velocity.y != 0)
        {
            //Move to Direction
            moveTo = rb.position + velocity * Time.fixedDeltaTime;
            rb.MovePosition(moveTo);
        }
    }
    //Gets an XY direction of magnitude from a radian angle relative to the x axis
    //Simple version
    Vector2 GetXYDirection(float angle, float magnitude) 
    {
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * magnitude;
    }
void MouseMovement()
    {
        Vector2 toClick = new Vector2(clickPos.x, clickPos.y) - rb.position;
       // Debug.Log(string.Format("Moving to [X: {0} Y: {0}]", toClick.x, toClick.y));
        float mag = toClick.magnitude;
        if(mag >= 0.1)
        {
            float div = (float)mag / moveSpeedMax;
            velocity = toClick / div;
            Debug.Log(string.Format("div {0}", div));
        } else { velocity = new Vector2(0, 0); }
    
    }
    void KeyBoardMovement()
    {
        isMovingByKey = true;
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
