using UnityEngine;
using System.Collections;



public class MainScript : MonoBehaviour {
	

	private MouseOrbit cameraOrbitScript;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().material.mainTexture = GameObject.Find("Data").GetComponent<Data>().selectedTexture;
	}
	
	void OnClick() {
	}

	void OnDrag() {

		if (cameraOrbitScript == null) {
			cameraOrbitScript = Camera.main.GetComponent<MouseOrbit> ();
		}
		cameraOrbitScript.OnDrag();
	}
}
