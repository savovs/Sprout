using UnityEngine;
using System.Collections;

public class rayCast : MonoBehaviour {
	public GameObject hoveredObject;
	public float selectRange = 50f;
	public float hitForce = 100f;
	public Transform Arm; // Will draw a line from where the "arm" is
	public Camera fpCamera;
	public Material hoveredMaterial;

	WaitForSeconds selectDuration = new WaitForSeconds(0.07f); // How long the ray will be visible for

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		// Take a position from the camera and convert it to a point in world space
		// In this case, right in front of the player
		Vector3 rayOrigin = fpCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;

		if (Physics.Raycast(rayOrigin, fpCamera.transform.forward, out hit, selectRange)) {
			Selectable selectable = hit.collider.GetComponent<Selectable>();
			
			if (selectable) {
				// selectable.GetComponent<Renderer>().materials[0] =  selectableMaterial;
				hoverObject(selectable.gameObject);
			}
			if (Input.GetMouseButtonDown(0)) {
				// If there is a shootable in the traced object, damage it
				
				if (selectable) {
					selectable.damage(1);
				}

				// Add force to it to move it around
				if (hit.rigidbody) {
					hit.rigidbody.AddForce(-hit.normal * hitForce);
				}

				Fruit fruit = hit.collider.GetComponent<Fruit>();
				if (fruit) {
					fruit.eat();
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
			Material[] mats = new Material[r.materials.Length];
			for(int i = 0; i < r.materials.Length - 1; i++) {
				mats[i] = r.materials[i];
			}
			r.materials = mats;

		}
		hoveredObject = null;
	}
}
