using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Animator myAnimator;
    Rigidbody2D myRigidbody;

    public float speed = 10;
    private bool facingRight = true;
    public float jumpForce;
    public int health = 10;
    public Collider2D myPlayerCollider;
    public Collider2D myEnemyCollider;

    // Use this for initialization
    void Start () {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Horizontal");
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
       transform.Translate(Time.deltaTime * (speed * horizontal), 0, 0);

        //TO BE CHECKED
        if(myRigidbody.velocity.y==0)
        {

          // myRigidbody.velocity = new Vector2(speed * horizontal, 0);
        }
        

        if(myRigidbody.velocity.y<0)
        {
            myAnimator.SetBool("land", true);
            myAnimator.ResetTrigger("jump");
        }
        else
        {  
            myAnimator.SetBool("land", false);
        }

        Flip(horizontal);
        _Input();
    }
    void Flip(float horizontal)
    {   
        // if we want the characher not to move while in air delete the /* */  and change the movement from transform.translate to myrigidbody.velocity;
        if (horizontal > 0 && !facingRight /*&& myRigidbody.velocity.y == 0*/ || horizontal < 0 && facingRight /*&& myRigidbody.velocity.y == 0*/)
        {
            facingRight = !facingRight;
            SpriteRenderer flipX = GetComponent<SpriteRenderer>();
            flipX.flipX = !facingRight;
        }
    }
    void _Input()
    {
        if(Input.GetKeyDown(KeyCode.Space)&&myRigidbody.velocity.y==0)
        {
            Jump();
        }
    }
    void Jump()
    {
        myRigidbody.AddForce(new Vector2(0, jumpForce));
        myAnimator.SetTrigger("jump");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.collider.tag== "Enemy")
        {
            health -= 1;

            if(health < 1)
            {
                Debug.Log("DEAD!");
            }
        }

      
    }

   
}
 