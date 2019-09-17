using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaggroundMove : MonoBehaviour
{

    Material florr;
    Vector2 offset;
    float y;


    void Start()
    {
        florr = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(FindObjectOfType<ScoreScript>().gameactive == true)
        {

            y = FindObjectOfType<speedHolder>().florrSpeed;


            offset = new Vector2(0, y);

            florr.mainTextureOffset += offset * (Time.deltaTime/10);

        }

        

    }
}
