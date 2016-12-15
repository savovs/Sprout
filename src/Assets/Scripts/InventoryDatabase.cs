using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class InventoryDatabase : MonoBehaviour {
	private List<Item> inventory = new List<Item>();

	void Awake() {
		// Add some items
		// arguments for Item(int id, string name, string rarity, int thirst)
		inventory.Add(new Item(0, "Peacebloom", "common", 2));
		inventory.Add(new Item(1, "Firebloom", "epic", 4));
		inventory.Add(new Item(2, "Earthroot", "rare", 2));
		inventory.Add(new Item(3, "Black Lotus", "legendary", 2));
		fetchItemByID(2);
	}

	public Item fetchItemByID(int id) {
		foreach(Item item in inventory)	{
			if(item.ID == id) {
				// Debug.Log("Item found: " + item.Name);
				return item;
			} 
		}
		Debug.Log("No item with that ID found in inventory.");
		return null;	
	}
}

public class Item {
	public int ID { get; set; }
	public string Name { get; set; }
	public string Rarity { get; set; }
	public int Thirst { get; set; }

	public Item(int id, string name, string rarity, int thirst) {
		this.ID = id;
		this.Name = name;
		this.Rarity = rarity;
		this.Thirst = thirst;
	}
}
