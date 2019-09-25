using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManeger : MonoBehaviour
{

    public bool isMutet = false;

    public GameObject on;
    public GameObject off;

    public GameObject Musik;


    private bool damp;
    private bool unDamp;
    private float val = 900;

    private void Start()
    {

        val = 900;

        isMutet = intToBool(PlayerPrefs.GetInt("mute", 0));

        if (isMutet)
        {
            off.SetActive(true);
            on.SetActive(false);
        }
        else
        {
            on.SetActive(true);
            off.SetActive(false);
        }

        Musik.SetActive(!isMutet);

    }

    private void Update()
    {

        if (damp)
        {

            val -= 12000f * Time.deltaTime;
            
            if (val <= 900)
            {
                damp = false;
                val = 900;
            }

            Musik.GetComponent<AudioLowPassFilter>().cutoffFrequency = (val);

        }

        if (unDamp)
        {

            val += 12000f * Time.deltaTime;
            
            if (val >= 22000)
            {
                unDamp = false;
                val = 22000;
            }

            Musik.GetComponent<AudioLowPassFilter>().cutoffFrequency = (val);

        }

    }


    public void dampeSound()
    {

        damp = true;
        
    }

    public void unDampeSound()
    {

        unDamp = true;
        
    }


    public void MusikOnOff()
    {

        isMutet = !isMutet;

        if (isMutet)
        {
            off.SetActive(true);
            on.SetActive(false);
        }
        else
        {
            on.SetActive(true);
            off.SetActive(false);
        }

        PlayerPrefs.SetInt("mute", boolToInt(isMutet));

        Musik.SetActive(!isMutet);

    }




    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

}

