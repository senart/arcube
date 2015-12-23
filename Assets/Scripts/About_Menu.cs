using UnityEngine;
using System.Collections;

public class About_Menu : MonoBehaviour
{
    Touch myTouch;
    Vector2 position;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            myTouch = Input.GetTouch(0);
            position = Camera.current.ScreenToWorldPoint(myTouch.position);

            switch (myTouch.phase)
            {
                case TouchPhase.Ended:

                    if (position.x < -1.5 && position.x > -2.75 && position.y > 3.25 && position.y < 5)
                    {
                        Application.LoadLevel("Main_Menu");
                    }
                    break;
            }
        }
    }
}
