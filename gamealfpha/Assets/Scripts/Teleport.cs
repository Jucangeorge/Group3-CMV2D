using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(Random.value);
        if (Random.value>0.5)
        {
         Player.transform.position = new Vector2(28f, 12f);
            Debug.Log(Random.value);
        }
        else
        {
            Player.transform.position = new Vector2(7f, 11f);
        }
    }
}
