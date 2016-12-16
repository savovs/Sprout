using UnityEngine;
using System.Collections;

[System.Serializable]
public class Seed : MonoBehaviour {
	public int ID;
	public string Name;
	public string Rarity;
	public int Thirst;
	public int Nutrition;
	public Inventory inventory;

	private void Start() {
		inventory = GameObject.Find("FirstPersonCharacter").GetComponent<Inventory>();
	}

	public void Collect() {
		Seed seedCollected = gameObject.GetComponent<Seed>();
		inventory.AddItem(seedCollected);
		gameObject.SetActive(false);
	}

	public Seed(int id, string name, string rarity, int thirst, int nutrition) {
		this.ID = id;
		this.Name = name;
		this.Rarity = rarity;
		this.Thirst = thirst;
		this.Nutrition = nutrition;
	}
}
