using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class Inventory : MonoBehaviour {
	public Seed selectedSeed;
	public int selectedSeedIndex;
	public bool hasSelectedSeed;
	public List<Seed> inventory = new List<Seed>();
	public List<GameObject> plantPrefabs = new List<GameObject>();


	void Awake() {
		// Add some items to database
		inventory.Add(new Seed(0, "Sweetleaf", "common", 3, 1));
		inventory.Add(new Seed(2, "Thornroot", "rare", 4, 1));
	}

	void Update() {
		// Select an item in the inventory by number 1 to 5
		if (Input.GetKeyDown(KeyCode.Alpha1) && inventory.Count > 0) {
			selectItem(0);
		}

		if(Input.GetKeyDown(KeyCode.Alpha2) && inventory.Count > 1) {
			selectItem(1);
		}

		if(Input.GetKeyDown(KeyCode.Alpha3) && inventory.Count > 2) {
			selectItem(2);
		}

		if(Input.GetKeyDown(KeyCode.Alpha4) && inventory.Count > 3) {
			selectItem(3);
		}

		if(Input.GetKeyDown(KeyCode.Alpha5) && inventory.Count > 4) {
			selectItem(4);
		}
	}
	
	public void AddItem(Seed item) {
		Debug.Log("Added a " + item.Name + "to inventory.");
		inventory.Add(item);
	}


	public void removeItemByIndex(int i) {
		inventory.RemoveAt(i);
		
		// Clear selected if index matches
		if (selectedSeedIndex == i) {
			selectedSeed = null;
			selectedSeedIndex = -1;
			hasSelectedSeed = false;
		}
	}

	public void removeSelectedItem() {
		inventory.RemoveAt(selectedSeedIndex);
		selectedSeed = null;
		selectedSeedIndex = -1;
		hasSelectedSeed = false;
	}

	void selectItem(int index) {
		Debug.Log("Selected a " + inventory[index].Name + " at inventory slot " + index);
		selectedSeed = inventory[index];
		selectedSeedIndex = index;
		hasSelectedSeed = true;
	}
}
