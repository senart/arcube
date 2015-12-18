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
	private bool MouseButtonDown = false;
	private bool MouseButtonUp = false;
	private Vector3 normal; // the triangle we hit with the RaycastHit, in order to cancel on drag
	private Collider clickedCollider;

	// Use this for initialization
	void Start () {
		check = GetComponent<Check_Square> ();
	}

	void Update() {
		// Input collections needs to be in Update because of frame skipping in FixedUpdate
		if (Input.GetMouseButtonDown (0)) {
			MouseButtonDown = true;
		}

		if (Input.GetMouseButtonUp (0)) {
			MouseButtonUp = true;
		}
	}

	void FixedUpdate() {
		if (MouseButtonDown) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 1000)) {
				normal = hit.normal;  // To prevent bug where you click a cube and onDrag anywhere else it still spawns a cube
				clickedCollider = hit.collider;
			}
			MouseButtonDown = false;
		}

		if (MouseButtonUp) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 1000)) {
				if (normal == hit.normal && clickedCollider == hit.collider) {
					spawnNewCube(hit);
				}
			}
			MouseButtonUp = false;
		}
	}

	private void spawnNewCube(RaycastHit hit) {
		Vector3 targetTransformPosition = hit.transform.localPosition;
		
		switch (getHitFace(hit)) {
		case HitFace.Up: targetTransformPosition += new Vector3 (0, transform.localScale.y, 0); break;
		case HitFace.Down: targetTransformPosition += new Vector3 (0, -transform.localScale.y, 0); break;
		case HitFace.East: targetTransformPosition += new Vector3 (transform.localScale.x, 0, 0); break;
		case HitFace.West: targetTransformPosition += new Vector3 (-transform.localScale.x, 0, 0); break;
		case HitFace.North: targetTransformPosition += new Vector3 (0, 0, transform.localScale.z); break;
		case HitFace.South: targetTransformPosition += new Vector3 (0, 0, -transform.localScale.z); break;
		case HitFace.None: Debug.LogError("FaceHit Should never be None!"); return;
		}

		GameObject newCube = (GameObject)Instantiate(prefab, targetTransformPosition, Quaternion.identity);
		newCube.transform.parent = transform;
		newCube.transform.localPosition = targetTransformPosition;
		newCube.transform.localScale = transform.localScale;
		Debug.Log("Done!");
		check.AddElement(newCube.transform.localPosition);
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
		if (incomingVec == Vector3.zero) return HitFace.Up;
		if (incomingVec == new Vector3(0, -2, 0)) return HitFace.Down;
		if (incomingVec == new Vector3(-1, -1, 0)) return HitFace.West;
		if (incomingVec == new Vector3(1, -1, 0)) return HitFace.East;

		Debug.Log(incomingVec);
		Debug.Log(Vector3.zero);
		return HitFace.None;
	}
}
