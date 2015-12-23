using UnityEngine;
using System.Collections;

public class Main_Menu : MonoBehaviour {

    Touch myTouch;
    Vector2 position;
    public Sprite start;
    public Sprite ar;
    public Sprite settings;
    public Sprite about;
	void Update () 
    {

        if (Input.touchCount > 0)
        {
            myTouch = Input.GetTouch(0);
            position = Camera.main.ScreenToWorldPoint(myTouch.position);

            switch (myTouch.phase)
            {
                case TouchPhase.Began:

                    if (position.x < 2.5 && position.x > -2.5 && position.y > -1 && position.y < 1)
                    {
                        GameObject.Find("Start_Button").GetComponent<SpriteRenderer>().sprite = start;
                    }
                    else if (position.x < 2.5 && position.x > -2.5 && position.y > -3 && position.y < -1.25)
                    {
                        GameObject.Find("Armode_Button").GetComponent<SpriteRenderer>().sprite = ar;
                    }
                    else if (position.x < -0.1 && position.x > -2.5 && position.y > -5 && position.y < -3.25)
                    {
                        GameObject.Find("Settings_Button").GetComponent<SpriteRenderer>().sprite = settings;
                    }
                    else if (position.x < 2.5 && position.x > 0.1 && position.y > -5 && position.y < -3.25)
                    {
                        GameObject.Find("About_Button").GetComponent<SpriteRenderer>().sprite = about;
                    }
                    break;

                case TouchPhase.Ended:

                    if (position.x < 2.5 && position.x > -2.5 && position.y > -1 && position.y < 1)
                    {
                        Application.LoadLevel("Level_Select");
                    }
                    else if (position.x < 2.5 && position.x > -2.5 && position.y > -3 && position.y < -1.25)
                    {
                        Application.LoadLevel("AR");
                    }
                    else if (position.x < -0.1 && position.x > -2.5 && position.y > -5 && position.y < -3.25)
                    {
                        Application.LoadLevel("Settings");
                    }
                    else if (position.x < 2.5 && position.x > 0.1 && position.y > -5 && position.y < -3.25)
                    {
                        Application.LoadLevel("About_Menu");
                    }
                    break;
            }
        }
	}
}
