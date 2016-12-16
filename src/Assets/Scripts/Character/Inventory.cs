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
			selectedSeed = inventory[0];
			selectedSeedIndex = 0;
			hasSelectedSeed = true;
		}

		if(Input.GetKeyDown(KeyCode.Alpha2) && inventory.Count > 1) {
			selectedSeed = inventory[1];
			selectedSeedIndex = 1;
			hasSelectedSeed = true;
		}

		if(Input.GetKeyDown(KeyCode.Alpha3) && inventory.Count > 2) {
			selectedSeed = inventory[2];
			selectedSeedIndex = 2;
			hasSelectedSeed = true;
		}

		if(Input.GetKeyDown(KeyCode.Alpha4) && inventory.Count > 3) {
			selectedSeed = inventory[3];
			selectedSeedIndex = 3;
			hasSelectedSeed = true;
		}

		if(Input.GetKeyDown(KeyCode.Alpha5) && inventory.Count > 4) {
			selectedSeed = inventory[4];
			selectedSeedIndex = 4;
			hasSelectedSeed = true;
		}
	}
	
	public void AddItem(Seed item) {
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
}
