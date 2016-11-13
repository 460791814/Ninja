using UnityEngine;
using System.Collections;

public class Award : MonoBehaviour {
    public float speed=1000;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(-Vector3.forward*speed*Time.deltaTime);
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
             AudioManager._instance.PlayCollectible();
            Destroy(this.gameObject);
        }
    }
}
