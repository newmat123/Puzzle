using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{


    float recordTime;
    float time;

    public bool gameactive;
    public Text record;
    public Text newrecord;

    void Start()
    {

        recordTime = PlayerPrefs.GetFloat("savedRecord");

    }

    void Update()
    {

        while (gameactive == true)
        {

            time += Time.deltaTime;

        }

        if(gameactive==false && time > 0f)
        {

            if(time > recordTime)
            {

                recordTime = time;

                PlayerPrefs.SetFloat("savedRecord", time);

                newrecord.text = "New Record!!";

            }

            record.text = time.ToString();

        }

    }

}
