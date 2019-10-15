using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public GameObject partikals;


    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touchPos.x < 2.25 && touchPos.x > -2.3)
            {

                touchPos.y = -1;

                transform.position = Vector2.MoveTowards(transform.position, touchPos, 30f*Time.deltaTime);
                
            }
                
        }

    }



    //partikals

    public void spawnPartikals()
    {

        Vector3 pos = transform.position + new Vector3(0, 1, 0);

        Instantiate(partikals, pos, transform.rotation);

    }

}
