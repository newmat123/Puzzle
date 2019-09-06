using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    

    void Update()
    {
        if (transform.position.x < 2.25 && transform.position.x > -2.3) {

            if (Input.touchCount > 0)
            {

                Touch touch = Input.GetTouch(0);

                Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                touchPos.z = 0;
                touchPos.y = -3;


                transform.position = touchPos;
                 
            }


        }else if (transform.position.x >= 2.25)
        {

            Vector3 back = transform.position;

            back.x = 2.23f;

            transform.position = back;

        }
        else if (transform.position.x <= -2.3)
        {

            Vector3 back = transform.position;

            back.x = -2.28f;

            transform.position = back;

        }

    }
}
