using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedHolder : MonoBehaviour
{

    public float Speed;
    public float Modifier;

    private float timer;

    void Start()
    {
        
    }


    void Update()
    {
        if(FindObjectOfType<ScoreScript>().gameactive == true)
        {
            timer += Time.deltaTime;

            Speed =  Modifier * Mathf.Sqrt(timer);
            if(Speed < 5)
            {
                Speed = 1;
            }

        }else if (FindObjectOfType<ScoreScript>().gameactive == false)
        {

            Speed = 0;
            timer = 0;

        }
        
        
    }
}
