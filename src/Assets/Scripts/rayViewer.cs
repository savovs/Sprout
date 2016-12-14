using UnityEngine;
using System.Collections;

public class rayViewer : MonoBehaviour {
	public float selectRange = 50f;
	public Camera fpCamera;

	// Helper script that draws a line to show where ray cast is
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 lineOrigin = fpCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
		Debug.DrawRay(lineOrigin, fpCamera.transform.forward * selectRange, Color.green);
	}
}
