using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Animator myAnimator;
    Rigidbody2D myRigidbody;

    public float speed = 10;
    private bool facingRight = true;
    public float jumpForce;
	// Use this for initialization
	void Start () {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        float horizontal = Input.GetAxis("Horizontal");
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
      //  transform.Translate(Time.deltaTime * (speed * horizontal), 0, 0);
        if(myRigidbody.velocity.y==0)
        {
            myRigidbody.velocity = new Vector2(speed * horizontal, 0);
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
        if (horizontal > 0 && !facingRight && myRigidbody.velocity.y == 0 || horizontal < 0 && facingRight&& myRigidbody.velocity.y == 0)
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
}
