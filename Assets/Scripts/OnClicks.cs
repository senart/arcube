using UnityEngine;
using System.Collections;

public class OnClicks : MonoBehaviour {

	public void GoToLevel1 () {
		Application.LoadLevel("tutorial");
	}
	public void GoToLevel2 (){
		Application.LoadLevel("Level2");
	}
	public void GoToLevel3 (){
		Application.LoadLevel("Level3");
	}
	public void GoToLevel4 (){
		Application.LoadLevel("Level4");
	}
	public void GoToLevel5 (){
		Application.LoadLevel("Level5");
	}
	public void GoBack (){
		Application.LoadLevel("main");
	}
}
