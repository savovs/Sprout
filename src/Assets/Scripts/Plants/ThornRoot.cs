using UnityEngine;
using System.Collections;

public class ThornRoot : MonoBehaviour {
	PlayerHealth playerHealth;
	Plant plant;

	void Start() {
		playerHealth = GameObject.Find("FirstPersonCharacter").GetComponent<PlayerHealth>();
		plant = gameObject.GetComponent<Plant>();

		// Set plant properties
		// args: (int id, string name, string rarity, int thirst)
		plant.initialize(1, "Thornroot", "rare", 4, 1);
	}

	// When plant is fully grown
	public void Ripen() {
		// ThornRoot has 50% chance to damage or heal player
		if(Random.value < .5) {
			playerHealth.damage(2);
		} else {
			playerHealth.heal(2);
		}
	}
}
