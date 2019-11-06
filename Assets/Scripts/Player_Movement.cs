using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeedMax = 3f;
    public Rigidbody2D rb;
    public float rotation;
    public Tilemap tilemap;
    Vector2 input;
    Vector2 velocity = new Vector2(0, 0);
    public Vector2 Velocity { get => velocity; set => velocity = value; }
    Vector2 moveTo;
    
    /*
    bool movingLeft;
    bool movingRight;
    bool movingUp;
    bool movingDown;
    */

    // Update is called once per frame
    void Update()
    {
        //get input
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        //Stop or slow down if no input
        if (input.x == 0)
        {
            if(Mathf.Abs(velocity.x) <= 0.05)
            {
                velocity.x = 0;
            } else { velocity.x *= (float)0.75; }                      
        }
        if (input.y == 0)
        {
            if (Mathf.Abs(velocity.y) <= 0.05)
            {
                velocity.y = 0;             
            } else { velocity.y *= (float)0.75; }                      
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
    void FixedUpdate()
    {
        
        if(velocity.x != 0 || velocity.y != 0)
        {
            rotation = Vector2.Angle(new Vector2(0, 1), velocity);
            if (velocity.x > 0)
            {
                rotation = -rotation;
            }
            rb.MoveRotation(rotation);
            //Move to Direction
            moveTo = rb.position + velocity * Time.fixedDeltaTime;
            rb.MovePosition(moveTo);
        }
        /*
         //Determine direction to rotate to
         if (Input.GetKeyDown("down")) { movingDown  = true; }
         if (Input.GetKey("up"))       { movingUp    = true; }
         if (Input.GetKey("left"))     { movingLeft  = true; }
         if (Input.GetKey("right"))    { movingRight = true; }
         //Rotate to Direction

         if ( movingUp && !movingDown && !movingLeft && !movingRight) { rb.MoveRotation(  0); }
         if ( movingUp && !movingDown && !movingLeft &&  movingRight) { rb.MoveRotation( 45); }
         if (!movingUp && !movingDown && !movingLeft &&  movingRight) { rb.MoveRotation( 90); }
         if (!movingUp &&  movingDown && !movingLeft &&  movingRight) { rb.MoveRotation(135); }
         if (!movingUp &&  movingDown && !movingLeft && !movingRight) { rb.MoveRotation(180); }
         if (!movingUp &&  movingDown &&  movingLeft && !movingRight) { rb.MoveRotation(225); }
         if (!movingUp && !movingDown &&  movingLeft && !movingRight) { rb.MoveRotation(270); }
         if ( movingUp && !movingDown &&  movingLeft && !movingRight) { rb.MoveRotation(315); }
         */
    }
}
