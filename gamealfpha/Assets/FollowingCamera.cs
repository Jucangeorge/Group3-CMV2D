using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour {


    public Transform player;
    public float pos;

    public float min;
    public float max;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(Mathf.Clamp(player.position.x, min, max), transform.position.y, transform.position.z);
	}
}
