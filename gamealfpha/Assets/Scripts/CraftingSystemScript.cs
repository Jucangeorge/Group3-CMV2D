using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftingSystemScript : MonoBehaviour
{
    public bool IsCrafting;

    public string CurrentCraftID;
    public int currentID;


    public List<Item> items = new List<Item>();

    public List<CraftableItem> CraftableItems = new List<CraftableItem>();

    public List<InputField> Craftslots = new List<InputField>();
    public List<Image> CraftslotsIMG = new List<Image>();


    public Image Result;
    public Sprite EmptySlot;




    // Update is called once per frame
    void Update()
    {

        if (IsCrafting)
        {
            GetCraftID();
        }
    }

    public void GetCraftID()
    {
        CurrentCraftID = "";
        for (int i = 0; i < 3; i++)
        {
            if (Craftslots[i].text != "")
            {
                CurrentCraftID += Craftslots[i].text;
<<<<<<< HEAD
                CraftslotsIMG[i].sprite = items[int.Parse(Craftslots[i].text)].icon; 
=======
                CraftslotsIMG[i].sprite = items[int.Parse(Craftslots[i].text)].img;
>>>>>>> ae021513158b4fd88193d600ff3e4b7ab34d9c09

            }
            else
            {
                CurrentCraftID += "E";
                CraftslotsIMG[i].sprite = EmptySlot;
            }
        }
        //getitemid;
        GetItemID(CurrentCraftID);
    }

    public void GetItemID(string CraftID)
    {
        for (int i = 0; i < CraftableItems.Count; i++)
        {
            if (CraftableItems[i].CraftID == CraftID)
            {
                currentID = CraftableItems[i].itemID;
                i = CraftableItems.Count;
<<<<<<< HEAD
                Result.sprite = items[currentID].icon;
=======
                Result.sprite = items[currentID].img;
>>>>>>> ae021513158b4fd88193d600ff3e4b7ab34d9c09

            }
            else
            {
                currentID = -1;
                Result.sprite = EmptySlot;
            }
        }
    }
}
<<<<<<< HEAD


=======
[System.Serializable]
public class Item
{

    public string name;
    public Sprite img;

}
>>>>>>> ae021513158b4fd88193d600ff3e4b7ab34d9c09

[System.Serializable]
public class CraftableItem
{
    public string name;
    public int itemID;
    public string CraftID;

}