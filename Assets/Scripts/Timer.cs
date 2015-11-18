using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public float timeLeft = 30;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("Time").GetComponent<UILabel> ().text = ("Time Remaining: " + ((int)timeLeft).ToString());
		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) {
			Application.LoadLevel("GameOver");
		}
	}
}
