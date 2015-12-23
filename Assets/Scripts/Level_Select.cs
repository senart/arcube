using UnityEngine;
using System.Collections;

public class Level_Select : MonoBehaviour {

    Touch myTouch;
    Vector2 position;
	void Update () {

        if (Input.touchCount > 0)
        {
            myTouch = Input.GetTouch(0);
            position = Camera.main.ScreenToWorldPoint(myTouch.position);

            switch (myTouch.phase)
            {
                case TouchPhase.Ended:

                    if (position.x < -1.25 && position.x > -2.8 && position.y > 3.1 && position.y < 5)
                    {
                        Application.LoadLevel("Main_Menu");
                    }
                    if (position.x < 0.7 && position.x > -0.7 && position.y > 1.8 && position.y < 3.2)
                    {
                        Application.LoadLevel("tutorial");
                    }
                    if (position.x < -1 && position.x > -2.4 && position.y > 0 && position.y < 1.4)
                    {
                        Application.LoadLevel("Level2");
                    }
                    if (position.x < 0.7 && position.x > -0.7 && position.y > 0 && position.y < 1.4)
                    {
                        Application.LoadLevel("Level3");
                    }
                    if (position.x < 2.4 && position.x > 1 && position.y > 0 && position.y < 1.4)
                    {
                        Application.LoadLevel("Level4");
                    }
                    if (position.x < -1 && position.x > -2.4 && position.y > -1.7 && position.y < -0.3)
                    {
                        Application.LoadLevel("Level5");
                    }
                    break;
            }
        }
	}
}
