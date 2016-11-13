using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float moveSpeed;
    public Transform play;
    public float maxDistance;
    private Animator anim;
	// Use this for initialization
	void Start () {
        play = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, play.position);
        if (distance < maxDistance)
        {
            if (play.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            Vector3 v = play.position - transform.position;
            transform.position += v.normalized * moveSpeed * Time.deltaTime;
            anim.SetBool("Run", true);
        }
        else {
            anim.SetBool("Run", false);
         }
	}
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (play.position.y > transform.position.y)
            { 
             //证明是踩到头了
                anim.SetBool("Death", true);
                Destroy(this.gameObject,0.1f);

            }
        }
    }
}
