using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    Rigidbody2D RB;

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
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

                FindObjectOfType<HealtBar>().SetSize(.5f);

                RB.AddForce(-collision.transform.position * 100);

                Destroy(GetComponent<Collider2D>());

            }

        }
        
    }

}
