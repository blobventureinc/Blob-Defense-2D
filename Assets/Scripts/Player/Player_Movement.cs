using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap = null;
    [SerializeField] private Tile_Targeting targetingScript = null;
    [SerializeField] private Rigidbody2D rb = null;
    public TileBase clickedTile;
    public float moveSpeedMax = 3f;
    public bool isMovingByKey;
    public bool isMoving;
    public bool mouseMovementDone; //to not repeatedly mine and target, is only false while MOVING by mouse, true when still by mouse
    public Vector3 clickPos;
    private Vector2 input;
    private Vector2 velocity;
    public Vector2 lastVelocity;
    private Vector2 moveTo;

    [SerializeField] Animator anim = null;

    private void Start()
    {
        isMovingByKey = true;
        mouseMovementDone = true;
        isMoving = false;
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(1))
        {
            mouseMovementDone = false;
            isMovingByKey = false;
            clickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickedTile = tilemap.GetTile(new Vector3Int((int)clickPos.x, (int)clickPos.y, 0));
        }
        else if (input.x != 0 || input.y != 0)
        {
            isMovingByKey = true;
            clickedTile = null;
        }
        if (isMovingByKey) { KeyBoardMovement(); }
        if (!isMovingByKey) { MouseMovement(); }
        if (velocity != new Vector2(0, 0))
        {
            lastVelocity = velocity;
        }
    }

    public void MoveTo(Vector3 clickPos)
    {
        isMovingByKey = false;
        mouseMovementDone = false;
        this.clickPos = clickPos;
        clickedTile = tilemap.GetTile(new Vector3Int((int)clickPos.x, (int)clickPos.y, 0));
    }

    void FixedUpdate()
    {
        if (velocity.x != 0 || velocity.y != 0)
        {
            isMoving = true;
            anim.SetBool("isMoving", true);
            anim.SetFloat("SpeedX", velocity.normalized.x);
            anim.SetFloat("SpeedY", velocity.normalized.y);
            moveTo = rb.position + velocity * Time.fixedDeltaTime;
            rb.MovePosition(moveTo);
        }
        else
        {
            isMoving = false;
            //anim.SetBool("isMoving", false);
        }
    }

    void MouseMovement()
    {
        if (!mouseMovementDone)
        {
            Vector2 toClick = new Vector2(clickPos.x - rb.position.x, clickPos.y - rb.position.y); //vector from character to click
            float mag = toClick.magnitude; //length of toClick
            if (mag >= 0.2)
            {
                float div = mag / moveSpeedMax; //how many times allowed movespeed fits in length
                if (div > 1.0)
                { //if more than one frame of max movespeed away; following this are different calculations for lower distances
                    velocity = new Vector2(toClick.x / div, toClick.y / div); //set to click as velocity, shortened to respect allowed movespeed
                }
                else
                {
                    if (div > 0.35)
                    {
                        velocity = toClick * div * 2; //simulates a finishing dash to the target location
                    }
                    else
                    { //Stop if close to target
                        velocity = new Vector2(0, 0);
                        targetingScript.MouseTargetTile(clickPos);
                        mouseMovementDone = true;
                    }
                }
            }
            else
            { //when very close by, stop
                velocity = new Vector2(0, 0);
                mouseMovementDone = true;
            }
        }
    }

    void KeyBoardMovement()
    {
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
