using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	void Update () {

        transform.Rotate(0,-1,0*Time.deltaTime);
	}
}
