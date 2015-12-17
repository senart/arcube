using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum HitFace
{
	None,
	Up,
	Down,
	East,
	West,
	North,
	South
}

public class PlayerScript : MonoBehaviour {

	public GameObject prefab;

	private Check_Square check;
	private Vector3 normal; // the triangle we hit with the RaycastHit, in order to cancel on drag
	private Collider clickedCollider;

	// Use this for initialization
	void Start () {
		check = GetComponent<Check_Square> ();
	}

	void FixedUpdate() {
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 1000)) {
				normal = hit.normal;  // To prevent bug where you click a cube and onDrag anywhere else it still spawns a cube
				clickedCollider = hit.collider;
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			Debug.Log("We clicked!");
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 1000)) {
				Debug.Log("Checking for drag...");
				if (normal == hit.normal && clickedCollider == hit.collider) {
					Debug.Log("Good to go!");
					spawnNewCube(hit);
				} else { Debug.Log("FAILED!"); }
			}

		}
	}

	private void spawnNewCube(RaycastHit hit) {
		Vector3 targetTransformPosition = hit.transform.position;
		
		switch (getHitFace(hit)) {
		case HitFace.Up: targetTransformPosition += new Vector3 (0, transform.localScale.y, 0); break;
		case HitFace.Down: targetTransformPosition += new Vector3 (0, -transform.localScale.y, 0); break;
		case HitFace.East: targetTransformPosition += new Vector3 (transform.localScale.x, 0, 0); break;
		case HitFace.West: targetTransformPosition += new Vector3 (-transform.localScale.x, 0, 0); break;
		case HitFace.North: targetTransformPosition += new Vector3 (0, 0, transform.localScale.z); break;
		case HitFace.South: targetTransformPosition += new Vector3 (0, 0, -transform.localScale.z); break;
		case HitFace.None: Debug.LogError("FaceHit Should never be None!"); break;
		}

		GameObject newCube = (GameObject)Instantiate(prefab, targetTransformPosition, Quaternion.identity);
		newCube.transform.parent = this.transform;
		Debug.Log("Done!");
		check.AddElement(newCube.transform.position);
		if (check.Check()) {
			GameObject.Find("Data").GetComponent<Data>().lastScore = (int)GameObject.Find("Time").GetComponent<Timer>().timeLeft;
			GameObject.Find("Data").GetComponent<Data>().lastLevel = Application.loadedLevelName;
			Application.LoadLevel("highscores");
		}
	}

	private HitFace getHitFace(RaycastHit hit)
	{
		Vector3 incomingVec = hit.normal - Vector3.up;
		
		if (incomingVec == new Vector3(0, -1, -1)) return HitFace.South;
		if (incomingVec == new Vector3(0, -1, 1)) return HitFace.North;
		if (incomingVec == new Vector3(0, 0, 0)) return HitFace.Up;
		if (incomingVec == new Vector3(0, -2, 0)) return HitFace.Down;
		if (incomingVec == new Vector3(-1, -1, 0)) return HitFace.West;
		if (incomingVec == new Vector3(1, -1, 0)) return HitFace.East;
		
		return HitFace.None;
	}
}
