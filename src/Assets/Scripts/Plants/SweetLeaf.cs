using UnityEngine;
using System.Collections;

public class SweetLeaf : MonoBehaviour {
	PlayerHealth playerHealth;
	Plant plant;

	void Start() {
		playerHealth = GameObject.Find("FirstPersonCharacter").GetComponent<PlayerHealth>();
		plant = gameObject.GetComponent<Plant>();

		// Set plant properties
		// args: (int id, string name, string rarity, int thirst, int nutrition)
		plant.initialize(1, "Sweetleaf", "rare", 2, 1);
	}

	// When plant is fully grown
	public void Ripen() {
		// Sweetleaf heals player substantially
		playerHealth.heal(4);
	}
}
