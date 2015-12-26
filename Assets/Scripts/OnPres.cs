using UnityEngine;
using System.Collections;

public class OnPres : MonoBehaviour {
    public Texture normal;
    public Texture pressed;
    void OnPress(bool isPressed) 
    {
        if (isPressed)
        {
            gameObject.GetComponent<UITexture>().mainTexture = pressed;
        }
        else
        {
            gameObject.GetComponent<UITexture>().mainTexture = normal;
        }
    }
}
