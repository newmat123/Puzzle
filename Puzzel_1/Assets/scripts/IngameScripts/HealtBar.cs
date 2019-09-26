using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBar : MonoBehaviour
{

    private Transform bar;

    public float damege;

    private void Start()
    {

        damege = 1;
        bar = transform.Find("bar");

    }

    private void Update()
    {
        
        if(damege <= 0.0001)
        {
            damege = 1;
            SetSize(damege);
            FindObjectOfType<ScoreScript>().endGame();
        }

    }


    public void plusLife(int add)
    {

        damege += ((1f / FindObjectOfType<Shop>().MoreHealth) * add);
        if(damege > 1)
        {
            damege = 1;
        }

        SetSize(damege);
    }


    public void doDamege()
    {

        damege -= (1f / FindObjectOfType<Shop>().MoreHealth);

        SetSize(damege);

    }

    void SetSize(float sizeNormelised)
    {
        
        bar.localScale = new Vector3(sizeNormelised, 1f);

    }

}
