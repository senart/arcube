﻿using UnityEngine;
using System.Collections;

public class MainScript : MonoBehaviour {
	
	public GameObject prefab;
	private float offset = 0.5F, eps = 0.01f;  // Cube wall divided by two for offset
	private MouseOrbit cameraOrbitScript;
	
	// Use this for initialization
	void Start () {
		
	}
	
	void OnClick() {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Physics.Raycast (ray, out hit, 100)) {
			Vector3 worldPosition = hit.point;
			Vector3 targetTransformPosition = this.transform.position;
			float x = targetTransformPosition.x;
			float y = targetTransformPosition.y;
			float z = targetTransformPosition.z;
			
			if (!(worldPosition.y < -offset + eps)) {
				if (Mathf.Abs (worldPosition.x - (x + offset)) < eps) {
					targetTransformPosition += new Vector3 (2 * offset, 0, 0);
				} else if (Mathf.Abs (worldPosition.y - (y + offset)) < eps) {
					targetTransformPosition += new Vector3 (0, 2 * offset, 0);
				} else if (Mathf.Abs (worldPosition.z - (z + offset)) < eps) {
					targetTransformPosition += new Vector3 (0, 0, 2 * offset);
				} else if (Mathf.Abs (worldPosition.x - (x - offset)) < eps) {
					targetTransformPosition += new Vector3 (- 2 * offset, 0, 0);
				} else if (Mathf.Abs (worldPosition.y - (y - offset)) < eps) {
					targetTransformPosition += new Vector3 (0, 0 - 2 * offset, 0);
				} else if (Mathf.Abs (worldPosition.z - (z - offset)) < eps) {
					targetTransformPosition += new Vector3 (0, 0, - 2 * offset);
				}
				
				GameObject newCube = (GameObject)Instantiate(prefab, targetTransformPosition, Quaternion.identity);
				newCube.transform.parent = this.transform.parent;
			}
		}
//		if (cameraOrbitScript == null) {
//			cameraOrbitScript = Camera.main.GetComponent<MouseOrbit> ();
//		}
//		cameraOrbitScript.

	}

	void OnDrag() {

		if (cameraOrbitScript == null) {
			cameraOrbitScript = Camera.main.GetComponent<MouseOrbit> ();
		}
		cameraOrbitScript.OnDrag();
	}
}
