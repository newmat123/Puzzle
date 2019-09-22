using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    Rigidbody2D RB;

    void Start()
    {

        Rigidbody2D RB = GetComponent<Rigidbody2D>();

        RB.velocity = new Vector2(0, -FindObjectOfType<speedHolder>().Speed);

    }

}
