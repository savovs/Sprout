using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour {
	public GameObject hoveredObject;
	public float selectRange = 50f;
	public float hitForce = 100f;
	public Camera fpCamera;
	public Material hoveredMaterial;

	public GameObject testPrefab;

	Inventory inventory;

	void Awake() {
		inventory = gameObject.GetComponent<Inventory>();
	}

	void Update () {
		// Take a position from the camera and convert it to a point in world space
		// In this case, right in front of the player
		Vector3 rayOrigin = fpCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;

		if(Physics.Raycast(rayOrigin, fpCamera.transform.forward, out hit, selectRange)) {
			Selectable selectable = hit.collider.GetComponent<Selectable>();
			Fruit fruit = hit.collider.GetComponent<Fruit>();
			Plant plant = hit.collider.GetComponent<Plant>();
			Seed seed = hit.collider.GetComponent<Seed>();

			if(selectable) {
				// Add outline material on hover
				hoverObject(selectable.gameObject);
			}

			if(Input.GetMouseButtonDown(0)) {
				if(selectable && plant) {
					plant.grow();
				}

				// Add force to wiggle it a bit
				if(hit.rigidbody) {
					hit.rigidbody.AddForce(-hit.normal * hitForce);
				}


				if(fruit) {
					fruit.Eat();
				}

				if(seed) {
					seed.Collect();
				}
			}

			Terrain terrain = hit.collider.GetComponent<Terrain>();
			if (terrain) {
				clearHover();
				if(Input.GetMouseButtonDown(0)) {
					// Get the inventory and if there's a selected seed, plant it
					inventory = gameObject.GetComponent<Inventory>();

					if(inventory.hasSelectedSeed) {
						GameObject foundPrefab = inventory.plantPrefabs.Find(item => item.name == inventory.selectedSeed.Name);
						Debug.Log(foundPrefab);
						inventory.removeSelectedItem();

						// If a prefab is found place it in the world
						if (foundPrefab) {
							GameObject placedObject = Instantiate(
								foundPrefab,
								hit.point, // Position to be placed at
								Quaternion.Euler(0, 0, 0) // Rotation
							) as GameObject;
						}
					}
				}
			}
		} else {
			clearHover();
		}
	}

	void hoverObject(GameObject obj) {
		if (hoveredObject) {
			if (obj == hoveredObject)
				return;
			clearHover();
		}

		hoveredObject = obj;

		Renderer[] renderers = hoveredObject.GetComponentsInChildren<Renderer>();
		foreach(Renderer r in renderers) {
			// Make an array with 1 more element and place the outline material there
			Material[] mats = new Material[r.materials.Length + 1];

			for(int i = 0; i < r.materials.Length; i++) {
				mats[i] = r.materials[i];
			}

			mats[mats.Length - 1] = hoveredMaterial;
			r.materials = mats;
		}
	} 

	void clearHover() {
		if (!hoveredObject) {
			return;
		}

		// Remove the outline material
		Renderer[] renderers = hoveredObject.GetComponentsInChildren<Renderer>();
		foreach(Renderer r in renderers) {
			Material[] mats = new Material[r.materials.Length - 1];
			for(int i = 0; i < mats.Length; i++) {
				mats[i] = r.materials[i];
			}
			r.materials = mats;

		}
		hoveredObject = null;
	}
}
