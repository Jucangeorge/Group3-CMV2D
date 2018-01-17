using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {
<<<<<<< HEAD
    public Transform itemsParent;

    Inventory inventory;

    InventorySlot[] slots;

	// Use this for initialization
	void Start () {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
=======

	// Use this for initialization
	void Start () {
		
>>>>>>> ae021513158b4fd88193d600ff3e4b7ab34d9c09
	}
	
	// Update is called once per frame
	void Update () {
		
	}
<<<<<<< HEAD
    void UpdateUI()
    {
        for(int i=0;i<slots.Length;i++)
        {
            if(i<inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }else
            {
                slots[i].ClearSlot();
            }
        }
    }
=======
>>>>>>> ae021513158b4fd88193d600ff3e4b7ab34d9c09
}
