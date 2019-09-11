using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    bool ishit;
    Rigidbody2D RB;

    private void Start()
    {
        ishit = false;
        RB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
        if(ishit == false && transform.position.y < -5.5f)
        {

            FindObjectOfType<HealtBar>().doDamege();

        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        

        if (collision.gameObject.tag == "Player")
        {

            if (transform.position.x < collision.transform.position.x + 0.2 && transform.position.x > collision.transform.position.x - 0.2)
            {

                transform.position = new Vector3(collision.transform.position.x ,collision.transform.position.y + 2.1f, 0);

                Destroy(gameObject);

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
