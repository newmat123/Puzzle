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

    public Animator animator;

    private void Start()
    {
        ishit = false;
        RB = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        //søger for at de forsviner når man dør
        if (FindObjectOfType<ScoreScript>().gameactive == false)
        {

            Destroy(gameObject);

        }

        //søger for at man ikke mister liv på de brikker, som man allerede har mistet et liv på, når de falder ned.
        if (ishit == false && transform.position.y < -5.5f && FindObjectOfType<ScoreScript>().gameactive == true)
        {

            FindObjectOfType<StressReceiver>().InduceStress(1);
            FindObjectOfType<HealtBar>().doDamege();
            Destroy(gameObject);

        }

        //søger for at de snapper og adder partikels efter 0,1 sec
        if(startTimer == true)
        {

            Player = GameObject.FindGameObjectWithTag("Player").transform;

            transform.rotation = Player.rotation;

            timeToDie += Time.deltaTime;
            transform.position = new Vector3(Player.position.x, Player.position.y + 0.91f, 0);

            if (timeToDie >= 0.1)
            {

                FindObjectOfType<playerMovement>().spawnPartikals();
                Destroy(gameObject);

            }

        }

    }


    


    private void OnCollisionEnter2D(Collision2D collision)
    {

        

        if (collision.gameObject.tag == "Player")
        {

            //chekker om man har remt brikken korrekt og om der er en standart brik
            if (transform.position.x < collision.transform.position.x + 0.2 && transform.position.x > collision.transform.position.x - 0.2)
            {

                Destroy(GetComponent<Collider2D>());
                GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
                animator.SetBool("isHit", true);
                startTimer = true;

                if(this.gameObject.tag == "Enemy")
                {

                    FindObjectOfType<ScoreScript>().PlusOne();

                }else if(this.gameObject.tag == "Life")
                {

                    FindObjectOfType<ScoreScript>().PlusOneSpecial();
                    FindObjectOfType<HealtBar>().plusLife(3);

                }
                else if (this.gameObject.tag == "Slow")
                {

                    FindObjectOfType<ScoreScript>().PlusOneSpecial();
                    FindObjectOfType<slowMotion>().DoSlowmotion();

                }

            }//ellers tager den et liv osv
            else
            {

                FindObjectOfType<StressReceiver>().InduceStress(1);
                Destroy(GetComponent<Collider2D>());
                RB.gravityScale = 1;
                RB.AddForce(-collision.transform.position * 130);

                FindObjectOfType<HealtBar>().doDamege();

            }

            ishit = true;

        }
        
    }

}
