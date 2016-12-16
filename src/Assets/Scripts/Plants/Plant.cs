using UnityEngine;
using System.Collections;

[System.Serializable]
public class Plant : MonoBehaviour {
	PlayerHealth playerHealth;
	ThornRoot thornRoot;

	public int ID { get; set; }
	public string Name { get; set; }
	public string Rarity { get; set; }

	// How many times to be "grown" before it becomes a fruit
	public int LeftToGrow { get; set; }

	// Health it restores after it becomes a fruit and is eaten
	public int Nutrition { get; set; }

	public void initialize(int id, string displayName, string rarity, int thirst, int nutrition) {
		this.ID = id;
		this.Name = displayName;
		this.Rarity = rarity;
		this.LeftToGrow = thirst;
		this.Nutrition = nutrition;
	}

	void Start() {
		playerHealth = GameObject.Find("FirstPersonCharacter").GetComponent<PlayerHealth>();
		thornRoot = gameObject.GetComponent<ThornRoot>();
	}

	public void grow() {
		playerHealth.damage(1);
		this.LeftToGrow -= 1;

		if(this.LeftToGrow <= 0) {
			if(thornRoot) {
				thornRoot.Ripen();
			}
			gameObject.SetActive(false);
		}
	}
}
