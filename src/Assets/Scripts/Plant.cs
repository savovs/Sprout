using UnityEngine;
using System.Collections;

public class Plant : MonoBehaviour {
	PlayerHealth playerHealth;
	public int currentHealth = 3;

	void Awake() {
		playerHealth = GameObject.Find("FirstPersonCharacter").GetComponent<PlayerHealth>();
	}

	public void grow() {
		playerHealth.damage(1);
		currentHealth -= 1;
		if(currentHealth <= 0) {
			gameObject.SetActive(false);
		}
	}
}
