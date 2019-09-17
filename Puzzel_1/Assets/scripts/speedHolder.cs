using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedHolder : MonoBehaviour
{

    public float florrSpeed;
    public float Speed;
    public float Modifier;

    private float timer;

    public void Reset()
    {

        Speed = 0;
        timer = 0;

    }


    void Update()
    {

        timer += Time.deltaTime;
        
        if (Speed < 20)
        {

            Speed = Modifier * Mathf.Sqrt(timer);
            florrSpeed = Speed;
            if (Speed < 2)
            {
                Speed = 2;
            }

        }
        else
        {
            Speed = 20;
        }
        
    }
}
