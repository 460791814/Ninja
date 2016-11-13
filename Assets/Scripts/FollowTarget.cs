using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

    public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 v = transform.position;
        v.x = target.position.x;
        transform.position= v;
	}
}
