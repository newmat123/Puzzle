using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMotion : MonoBehaviour
{

    public GameObject[] holders;
    public GameObject[] slBottun;

    public float slowDoenFactor = 0.5f;
    public float slowdownLength = 5f;

    private float timeTo;

    private bool slowMo = false;


    public void Start()
    {
        
        if(FindObjectOfType<Shop>().holder1)
        {
            holders[0].SetActive(true);
            if (FindObjectOfType<Shop>().holder2)
            {
                holders[1].SetActive(true);
                if (FindObjectOfType<Shop>().holder3)
                {
                    holders[2].SetActive(true);
                }
                else
                {
                    holders[2].SetActive(false);
                }
            }
            else
            {
                holders[1].SetActive(false);
                holders[2].SetActive(false);
            }
        }
        else
        {
            for(int i = 0; i < holders.Length; i++)
            {
                holders[i].SetActive(false);
            }
        }

        for(int i = 0; i < slBottun.Length; i++)
        {
            slBottun[i].SetActive(false);
        }

    }


    private void Update()
    {

        if (slowMo)
        {

            timeTo += Time.deltaTime;

            if(timeTo > FindObjectOfType<Shop>().SlowmoTime || FindObjectOfType<ScoreScript>().gameactive == false) 
            {

                Time.timeScale += (1f / slowdownLength) * Time.deltaTime;
                Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

                if(Time.timeScale == 1)
                {
                    timeTo = 0;
                    slowMo = false;
                }

            }
            
        }
        
    }

    public void getSlowMo()
    {
        

        if(slBottun[0].activeInHierarchy == true)
        {

            if(slBottun[1].activeInHierarchy == true)
            {

                if(slBottun[2].activeInHierarchy == false)
                {
                    if (holders[2].activeInHierarchy)
                    {
                        slBottun[2].SetActive(true);
                    }
                    
                }

            }
            else
            {

                if (holders[1].activeInHierarchy)
                {
                    slBottun[1].SetActive(true);
                }
                
            }
            
        }
        else
        {
            slBottun[0].SetActive(true);
        }

    }

    public void DoSlowmotion()
    {
        if(slowMo == false)
        {
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            slowMo = true;

            if (slBottun[2].activeInHierarchy == false)
            {

                if (slBottun[1].activeInHierarchy == false)
                {

                    slBottun[0].SetActive(false);

                }
                else
                {
                    slBottun[1].SetActive(false);
                }

            }
            else
            {
                slBottun[2].SetActive(false);
            }

        }

    }
    
}
