using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public Transform[] spawnLocations;
	public GameObject[] prefabsToSpawn;
	public GameObject[] instantiatedPrefabsToSpawn;

	private void Start() {
		Spawn();
	}
	void Spawn() {
		instantiatedPrefabsToSpawn[0] = Instantiate(
			prefabsToSpawn[0],
			spawnLocations[0].transform.position,
			Quaternion.Euler(0, 0, 0)
		) as GameObject;
	}
}
