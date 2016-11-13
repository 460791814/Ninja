using UnityEngine;
using System.Collections;

public class PlayMove : MonoBehaviour {

    public float force_move=70;
    private Animator anim;
    private bool isGround = false;//是否在地面上
    private bool isWall = false;//是否靠墙
    public float jumpVelocity;
    private Transform wall;
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Horizontal", Mathf.Abs(h));
        if (isWall==false)
        {
         
            if (h > 0.05f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                rigidbody2D.AddForce(Vector2.right * force_move);
            }
            else if (h < -0.05f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                rigidbody2D.AddForce(-Vector2.right * force_move);
            }
            if (isGround && Input.GetKeyDown(KeyCode.Space))
            {

                //rigidbody2D.AddForce(Vector2.up * jumpVelocity);
                Vector2 tempVelocity = rigidbody2D.velocity;
                tempVelocity.y = jumpVelocity;
                rigidbody2D.velocity = tempVelocity;
            }
            // print(rigidbody2D.velocity);
            anim.SetFloat("Vertical", rigidbody2D.velocity.y);
        }
        else { 
        //靠在墙上
        
        }
	}
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = true; isWall = false;
        }
        if (collision.collider.tag == "Wall")
        {
            
            isWall = true;
            wall = collision.transform;
            rigidbody2D.gravityScale = 5;
        }
        anim.SetBool("IsGround", isGround);
        anim.SetBool("IsWall", isWall);
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isGround = false;
        }
        if (collision.collider.tag == "Wall")
        {
            isWall = false;
            rigidbody2D.gravityScale = 20;
        }
        anim.SetBool("IsGround",isGround);
        anim.SetBool("IsWall", isWall);
    }
    public void ChangeDir()
    {
        if (wall.transform.position.x > transform.position.x)
        {
            //墙在任务的右边
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
