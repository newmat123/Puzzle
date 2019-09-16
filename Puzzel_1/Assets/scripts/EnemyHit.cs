﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    float timeToDie = 0;
    bool ishit;
    bool startTimer = false;
    Rigidbody2D RB;
    Vector3 player;

    private void Start()
    {
        ishit = false;
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        if(ishit == false && transform.position.y < -5.5f && FindObjectOfType<ScoreScript>().gameactive == true)
        {

            FindObjectOfType<HealtBar>().doDamege();
            Destroy(gameObject);

        }

        if(startTimer == true)
        {

            timeToDie += Time.deltaTime;
            transform.position = new Vector3(player.x, player.y + 0.8f, 0);

            if (timeToDie >= 0.15)
            {
                Destroy(gameObject);

            }

        }

    }


    


    private void OnCollisionEnter2D(Collision2D collision)
    {

        

        if (collision.gameObject.tag == "Player")
        {

            player = collision.transform.position;

            if (transform.position.x < collision.transform.position.x + 0.2 && transform.position.x > collision.transform.position.x - 0.2)
            {

                Destroy(GetComponent<Collider2D>());
                FindObjectOfType<StressReceiver>().InduceStress(1);

                startTimer = true;

            }
            else
            {

                Destroy(GetComponent<Collider2D>());

                RB.gravityScale = 1;
                RB.AddForce(-collision.transform.position * 100);

                FindObjectOfType<HealtBar>().doDamege();

            }

            ishit = true;

        }
        
    }

}
