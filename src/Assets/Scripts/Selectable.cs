using UnityEngine;
using System.Collections;

public class Selectable : MonoBehaviour {
	public Material outline;
	public int currentHealth = 3;

	public void damage(int damageAmount) {
		currentHealth -= damageAmount;
		if (currentHealth <= 0) {
			gameObject.SetActive(false);
		}
	}
}
