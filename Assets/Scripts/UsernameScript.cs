using UnityEngine;
using System.Collections;

public class UsernameScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		this.GetComponent<UILabel> ().text = GameObject.Find ("Data").GetComponent<Data> ().username;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void usernameSubmit() {
		string nameEntered = this.GetComponent<UILabel> ().text;
		if (nameEntered == "Enter Your Name" || nameEntered == "" ) {
			this.GetComponent<UILabel> ().text = GameObject.Find ("Data").GetComponent<Data> ().username;
		} else {
			GameObject.Find ("Data").GetComponent<Data> ().username = nameEntered;
		}

	}
}
