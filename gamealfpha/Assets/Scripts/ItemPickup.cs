using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ItemPickup : MonoBehaviour {

    public Item item;
   // public Collider2D Player;
	// Use this for initialization
	void Start () {
        //item = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Pickup();
        }
        

       
    }
    void Pickup()
    {
        Debug.Log("Picking up" + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        if(wasPickedUp)
        Destroy(gameObject);
    }

}
