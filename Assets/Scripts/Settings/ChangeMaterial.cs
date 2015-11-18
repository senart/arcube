using UnityEngine;
using System.Collections;

public class ChangeMaterial : MonoBehaviour {
    
    void Start()
    {
        GetComponent<Renderer>().material.mainTexture = GameObject.Find("Data").GetComponent<Data>().selectedTexture;
    }
           
    
}
