using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBar : MonoBehaviour
{

    private Transform bar;

    public float damege;
    public float amountOfDamege;

    private void Start()
    {

        amountOfDamege = 0.2f;
        damege = 1;
        bar = transform.Find("bar");

    }

    private void Update()
    {
        
        if(damege < 0.01)
        {
            damege = 1;
            SetSize(damege);
            FindObjectOfType<ScoreScript>().endGame();
        }

    }

    public void doDamege()
    {

        damege = damege - amountOfDamege;

        SetSize(damege);

    }

    void SetSize(float sizeNormelised)
    {
        
        bar.localScale = new Vector3(sizeNormelised, 1f);

    }

}
