using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Data : MonoBehaviour {
    
    public List<Texture> textures;
	public Texture selectedTexture;
	public string username;
	public int lastScore;
	public string lastLevel;

	private static bool spawned = false;

	public void setTexture(int n) {
		selectedTexture = textures [n];
	}

    void Awake () {
		if (spawned) {
			DestroyImmediate(this);
		} else {
			spawned = true;
			DontDestroyOnLoad(this);
		}
		selectedTexture = textures [0];

		username = "Guest" + ranNumber();
		lastScore = 0;
		lastLevel = "0";
	}

	public string ranNumber()
	{
		float ranNum = Random.Range(0.0F, 1000.0F);
		int randomNumber = (int)ranNum;
		string num = randomNumber.ToString();
		return num;
	}
}
