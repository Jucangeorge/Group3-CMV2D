using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour {
    Rigidbody2D myRigidbody;
    public int EnemySpeed; //set to private, its public to debug;
    public int moveDirection; // set to private, its public to debug;
    private bool facingRight = true;
    public int health;//not used for now might be used if the enemy have more than 1 life
    
    void Start () {
        
        myRigidbody = GetComponent<Rigidbody2D>(); 

    }
	
	// Update is called once per frame
	void Update () {

        //raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(moveDirection, 0));
        RaycastHit2D hitdown = Physics2D.Raycast(((Vector2)transform.position) + new Vector2(2f*moveDirection,0), new Vector2(0, -1));
        //draw raycast
        Debug.DrawRay(((Vector2)transform.position) + new Vector2(2f*moveDirection, 0), new Vector2(0, -1));


        //movement
        myRigidbody.velocity = new Vector2(moveDirection, 0) * EnemySpeed;

        //if there is no ground upfront the AI will turn around
        if(hitdown.collider==null)
        {
                Flip();
        }
       //forgot why i did this remember to check it again
        if(hit.distance==0)
        {
            Debug.Log("hit.distance==0");
        } //if there is an object 1.2 units in front of it will change direction
        else if (hit.distance < 1.2f)
        {
            Flip();
        }     
    }
    // filp or change direction, you flip the sprite so therefore the name
    void Flip()
    {
        if (moveDirection>0)
        {
            moveDirection = -1;
           // transform.Rotate(0, 180, 0);
        }
        else
        {
            moveDirection = 1;
          //  transform.Rotate(0, 0, 0);
        }
 
        facingRight = !facingRight;
        SpriteRenderer flipX = GetComponent<SpriteRenderer>();
        flipX.flipX = !facingRight;

    }
}