using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	public int maxHealth = 5;
	public int currentHealth;
	public Text healthText;
	public Image heartImage;

	bool isDead;

	void Awake() {
		currentHealth = maxHealth;
		healthText.text = currentHealth.ToString();
	}
	
	void Update () {

	}

	public void damage(int amount) {
		currentHealth -= amount;
		healthText.text = currentHealth.ToString();
		if(currentHealth <= 0) {
			isDead = true;
		}
	}

	public void heal(int amount) {
		// Don't let health become more than maxHealth
		if (currentHealth < maxHealth) {
			if (currentHealth + amount >= maxHealth) {
				currentHealth = maxHealth;
			} else {
				currentHealth += amount;
			}
			
			healthText.text = currentHealth.ToString();
		}
	}
}