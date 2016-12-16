using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour {
	PlayerHealth playerHealth;

	void Awake() {
		playerHealth = GameObject.Find("FirstPersonCharacter").GetComponent<PlayerHealth>();
	}

	public void Eat() {
		playerHealth.heal(1);
		gameObject.SetActive(false);
	}
}
