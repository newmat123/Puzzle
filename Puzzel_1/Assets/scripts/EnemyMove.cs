using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    Rigidbody2D RB;

    void Start()
    {

        Rigidbody2D RB = GetComponent<Rigidbody2D>();

        RB.velocity = new Vector2(0,-2 * FindObjectOfType<speedHolder>().Speed);

    }

    void Update()
    {
        
        if(transform.position.y < -6)
        {
            
            Destroy(gameObject);

        }

        if(FindObjectOfType<ScoreScript>().gameactive == false)
        {

            //partikals her og noget effekt 
            Destroy(gameObject);

        }

    }

}
