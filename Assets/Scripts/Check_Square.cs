using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Check_Square : MonoBehaviour {
   
    Dictionary<int, int> dictionaryX = new Dictionary<int, int>();
    Dictionary<int, int> dictionaryY = new Dictionary<int, int>();
    Dictionary<int, int> dictionaryZ = new Dictionary<int, int>();

	void Start() {
		foreach (Transform child in this.transform.GetComponentInChildren<Transform>()) {
			AddElement(child.localPosition);
		}
	}

    public void AddElement (Vector3 input)
    {
        if (!dictionaryX.ContainsKey((int)input.x))
        {
            dictionaryX.Add((int)input.x, 1);
        }
        else
        {
            int oldValue = dictionaryX[(int)input.x];
            dictionaryX[(int)input.x] = oldValue + 1;
        }

        if (!dictionaryY.ContainsKey((int)input.y))
        {
            dictionaryY.Add((int)input.y, 1);
        }
        else
        {
            int oldValue = dictionaryY[(int)input.y];
            dictionaryY[(int)input.y] = oldValue + 1;
        }

        if (!dictionaryZ.ContainsKey((int)input.z))
        {
            dictionaryZ.Add((int)input.z, 1);
        }
        else
        {
            int oldValue = dictionaryZ[(int)input.z];
            dictionaryZ[(int)input.z] = oldValue + 1;
        }
    }
    public void RemoveElement(Vector3 input)
    {
        if (dictionaryX[(int)input.x] > 1)
        {
            int oldValue = dictionaryX[(int)input.x];
            dictionaryX[(int)input.x] = oldValue - 1;
        }
        else
        {
            dictionaryX.Remove((int)input.x);
        }

        if (dictionaryY[(int)input.y] > 1)
        {
            int oldValue = dictionaryY[(int)input.y];
            dictionaryY[(int)input.y] = oldValue - 1;
        }
        else
        {
            dictionaryY.Remove((int)input.y);
        }

        if (dictionaryZ[(int)input.z] > 1)
        {
            int oldValue = dictionaryZ[(int)input.z];
            dictionaryZ[(int)input.z] = oldValue - 1;
        }
        else
        {
            dictionaryZ.Remove((int)input.z);
        }
    }
    public bool Check()
    {
        int i = -1;

        foreach (KeyValuePair<int, int> item in dictionaryX)
        {
            if (i != -1)
            {
                if (i!= item.Value) { return false; }
            }
            else { i = item.Value;  }
        }
        int j = -1;

        foreach (KeyValuePair<int, int> item in dictionaryY)
        {
            if (j != -1)
            {
                if (j != item.Value) { return false; }
            }
            else { j = item.Value; }
        }
        int k = -1;

        foreach (KeyValuePair<int, int> item in dictionaryZ)
        {
            if (k != -1)
            {
                if (k != item.Value) { return false; }
            }
            else { k = item.Value; }
        }
        return true;
    }
}
