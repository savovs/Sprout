using UnityEngine;
using System.Collections;

public class Fruit : MonoBehaviour {
	private AudioSource eatAudio;
	public void eat() {
		if (eatAudio != null) {
			eatAudio.Play();
		}
		gameObject.SetActive(false);
	}
}
