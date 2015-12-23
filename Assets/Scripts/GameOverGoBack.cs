using UnityEngine;
using System.Collections;

public class GameOverGoBack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void goBackToLevelSelect() {
		Application.LoadLevel ("Level_Select");
	}
}
