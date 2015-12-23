using UnityEngine;
using System.Collections;

public class UIMain : MonoBehaviour {
	public void startClicked() {
		Application.LoadLevel ("Level_Select");
	}

	public void settingsClicked() {
		Application.LoadLevel ("Settings");
	}

	public void aboutClicked() {
		Application.LoadLevel ("About_Menu");
	}

	public void ARClicked() {
		Application.LoadLevel ("AR");
	}
}
