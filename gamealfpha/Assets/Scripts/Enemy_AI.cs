using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AI : MonoBehaviour {
    Rigidbody2D myRigidbody;
    public int EnemySpeed;
    public int moveDirection;
    private bool facingRight = true;
    public Collider2D myPlayerCollider;
    public Collider2D myEnemyCollider;
    public Movement Myplayer;
    public int health;
    
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

        //enemy attack to be detailed
        if(myEnemyCollider.IsTouching(myPlayerCollider))
        {
            Debug.Log("enemyhit");
        }

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
        }
        else if (hit.distance < 1.2f)
        {
            Flip();
        }     
    }

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