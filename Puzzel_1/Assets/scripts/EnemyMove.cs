using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    

    void Start()
    {

        Rigidbody2D RB = GetComponent<Rigidbody2D>();

        RB.velocity = new Vector2(0,-5);

    }

    void Update()
    {
        
        if(transform.position.y < -4)
        {

            FindObjectOfType<HealtBar>().SetSize(.2f);

            Destroy(this);

        }

    }
}
