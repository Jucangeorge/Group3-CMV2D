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
   
    
    void Start () {

        myRigidbody = GetComponent<Rigidbody2D>(); 

    }
	
	// Update is called once per frame
	void Update () {

        //raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(moveDirection, 0));
        RaycastHit2D hitdown = Physics2D.Raycast(((Vector2)transform.position) + new Vector2(2f,0), new Vector2(0, -1));
        Debug.DrawRay(((Vector2)transform.position) + new Vector2(2f, 0), new Vector2(0, -1));
        if(myEnemyCollider.IsTouching(myPlayerCollider))
        {
            Debug.Log("hit");
        }
        //movement
        myRigidbody.velocity = new Vector2(moveDirection, 0) * EnemySpeed;


        if(hitdown.collider==null)
        {
            if(moveDirection>0)
            {
                Flip();
            }
        }
       
        if(hit.distance==0)
        {
           
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