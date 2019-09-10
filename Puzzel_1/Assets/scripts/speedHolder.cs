using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedHolder : MonoBehaviour
{

    public float Speed;

    void Start()
    {
        
    }


    void Update()
    {

        Speed = Time.deltaTime;

    }
}
