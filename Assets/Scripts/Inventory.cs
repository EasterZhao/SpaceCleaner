using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory 
{
    private List<Item> itemList;
    public Inventory()
    {
        itemList = new List<Item>();
        Debug.Log("INVENTORY");
        AddItem(new Item{ itemType = Item.ItemType.Item1, amount = 1});
    }

    public void AddItem(Item item)
    {
        itemList.Add(item);
    }

}
