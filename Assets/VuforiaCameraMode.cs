using UnityEngine;
using System.Collections;
using Vuforia;

public class VuforiaCameraMode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		VuforiaBehaviour.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
		VuforiaBehaviour.Instance.RegisterOnPauseCallback(OnPaused);
	}

	private void OnVuforiaStarted()
	{
		bool focusModeSet = CameraDevice.Instance.SetFocusMode(
			CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		if (!focusModeSet) {
			Debug.Log("Camera Focus mode NOT set");
		}
	}
	
	private void OnPaused(bool paused)
	{
		if (!paused) // resumed
		{
			// Set again autofocus mode when app is resumed
			CameraDevice.Instance.SetFocusMode(
				CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
		}
	}
}
