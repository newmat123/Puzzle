﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public GameObject partikals;
    public GameObject elements;


    void FixedUpdate()
    {


        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touchPos.x < 2.25 && touchPos.x > -2.3)
            {

                touchPos.z = 0;
                touchPos.y = -1;


                transform.position = touchPos;

            }
                
        }

    }



    //partikals

    public void spawnPartikals()
    {

        Vector3 pos = transform.position + new Vector3(0, 1, 0);


        elements = Instantiate(partikals, pos, transform.rotation);
        Destroy(elements, 1);

    }

   

}