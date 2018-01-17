using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PanelScript : MonoBehaviour {
    public GameObject Inventory;
    public GameObject Crafting;
    bool openInventory = false;
    bool openCraft = false;
	// Use this for initialization
	void Start () {
        Inventory.gameObject.SetActive(false);
        Crafting.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        
		if(Input.GetKeyDown("i"))
        {   if (openInventory)
            {
                Inventory.gameObject.SetActive(false);
                openInventory = false;
            }
            else
            {
                Inventory.gameObject.SetActive(true);
                openInventory = true;
            }
        }
        else if(Input.GetKeyDown("c"))
        {
            if (openCraft)
            {
                Crafting.gameObject.SetActive(false);
                openCraft = false;
            }
            else
            {
                Crafting.gameObject.SetActive(true);
                openCraft = true;
            }
        }
	}

    



}
