using UnityEngine;
using System.Collections;

public class Checkbox : MonoBehaviour {

    public bool k;
    void Start () {
        
        k = true;
	}
    public bool check ()
    {
        return k;
    }
    public void change()
    {
        if (k == true) k = false;
        else k = true;
    }
    public bool returnk()
    {
        return !k;
    }

    void Update () {
	
	}
}
