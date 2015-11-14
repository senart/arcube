using UnityEngine;
using System.Collections;

public class ChangePat : MonoBehaviour {
    
    public int texture;

	void OnClick () {
        if (GameObject.Find("Remove ADS").GetComponent<Checkbox>().returnk() == false)
        {
            GameObject.Find("Data").GetComponent<Data>().setTexture(texture);
            //GameObject.Find("pCube24").GetComponent<Renderer>().material.mainTexture = GameObject.Find("Data").GetComponent<Data>().textures[GameObject.Find("Data").GetComponent<Data>().n];
			Debug.Log(GameObject.Find("Data").GetComponent<Data>().selectedTexture);
        }
    }
}
