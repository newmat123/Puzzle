using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    Transform Player;

    float timeToDie = 0;
    bool ishit;
    bool startTimer = false;
    Rigidbody2D RB;

    private void Start()
    {

        ishit = false;
        RB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        if(ishit == false && transform.position.y < -5.5f && FindObjectOfType<ScoreScript>().gameactive == true)
        {

            FindObjectOfType<StressReceiver>().InduceStress(1);
            FindObjectOfType<HealtBar>().doDamege();
            Destroy(gameObject);

        }

        if(startTimer == true)
        {

            Player = GameObject.FindGameObjectWithTag("Player").transform;

            transform.rotation = Player.rotation;

            timeToDie += Time.deltaTime;
            transform.position = new Vector3(Player.position.x, Player.position.y + 0.91f, 0);

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


            if (transform.position.x < collision.transform.position.x + 0.2 && transform.position.x > collision.transform.position.x - 0.2)
            {

                Destroy(GetComponent<Collider2D>());

                startTimer = true;

            }
            else
            {

                Destroy(GetComponent<Collider2D>());
                FindObjectOfType<StressReceiver>().InduceStress(1);
                RB.gravityScale = 1;
                RB.AddForce(-collision.transform.position * 130);

                FindObjectOfType<HealtBar>().doDamege();

            }

            ishit = true;

        }
        
    }

}
