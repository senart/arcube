using UnityEngine;
using System.Collections;

public class UIMain : MonoBehaviour {
	public void startClicked() {
		Application.LoadLevel ("levelselect");
	}

	public void settingsClicked() {
		Application.LoadLevel ("settings");
	}

	public void aboutClicked() {
		Application.LoadLevel ("about");
	}
}
