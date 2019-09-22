using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pil : MonoBehaviour
{

    float timer = 0;

    void Update()
    {

        timer += Time.deltaTime;

        if(timer > 3)
        {
            Destroy(this.gameObject);
        }

        if(FindObjectOfType<ScoreScript>().gameactive == false)
        {
            Destroy(this.gameObject);
        }

    }
}
