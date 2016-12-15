using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour {
	PlayerHealth playerHealth;

	void Awake() {
		playerHealth = GameObject.Find("FirstPersonCharacter").GetComponent<PlayerHealth>();
	}

	public void eat() {
		playerHealth.restoreHealth(1);
		gameObject.SetActive(false);
	}
}
