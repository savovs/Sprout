using UnityEngine;
using System.Collections;

public class rayCast : MonoBehaviour {
	public float selectRange = 50f;
	public float hitForce = 100f;
	public Transform Arm; // Will draw a line from where the "arm" is
	public Camera fpCamera;

	WaitForSeconds selectDuration = new WaitForSeconds(0.07f); // How long the ray will be visible for
	private AudioSource selectAudio;
	private LineRenderer laserLine;

	void Start () {
		laserLine = GetComponent<LineRenderer>();
		selectAudio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		// Detect mouse click
		if (Input.GetMouseButtonDown(0)) {
			StartCoroutine(selectEffect());

			// Take a position from the camera and convert it to a point in world space
			// In this case, right in front of the player
			Vector3 rayOrigin = fpCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
			RaycastHit hit;

			laserLine.SetPosition(0, Arm.position);
			if (Physics.Raycast(rayOrigin, fpCamera.transform.forward, out hit, selectRange)) {
				// If it hits something, draw the 2nd point at the place of hit
				laserLine.SetPosition(1, hit.point);
			} else {
				// If no hit, draw second point at selectRange in the direction of the camera
				laserLine.SetPosition(1, rayOrigin + (fpCamera.transform.forward * selectRange));
			}
		}
	}

	IEnumerator selectEffect() {
		// selectAudio.Play();
		laserLine.enabled = true;
		yield return selectDuration;
		laserLine.enabled = false;
	}
}
