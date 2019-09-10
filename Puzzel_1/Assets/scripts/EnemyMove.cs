using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    void Start()
    {

        HealtBar hb = this.GetComponent<HealtBar>();

        Rigidbody2D RB = GetComponent<Rigidbody2D>();

        RB.velocity = new Vector2(0,-5);

        //hb.SetSize(.4f);

    }

    void Update()
    {
        
        

    }
}
