using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManeger : MonoBehaviour
{

    public bool isMutet = false;
    public bool SFXisMutet = false;

    public GameObject on;
    public GameObject off;

    public GameObject on1;
    public GameObject off1;

    public GameObject Musik;

    public GameObject hit;
    public GameObject Hurt;
    public GameObject Bottun;

    private AudioSource a;
    private bool damp;
    private bool unDamp;
    private float val = 900;

    private void Start()
    {

        val = 900;

        a = Musik.GetComponent<AudioSource>();

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

        a.mute = isMutet;

        SFXisMutet = intToBool(PlayerPrefs.GetInt("muteSFX", 0));

        if (SFXisMutet)
        {
            off1.SetActive(true);
            on1.SetActive(false);
        }
        else
        {
            on1.SetActive(true);
            off1.SetActive(false);
        }
    }

    private void FixedUpdate()
    {

        if (damp && !unDamp)
        {

            val -= 5000f * Time.fixedDeltaTime;
            
            if (val <= 900)
            {
                damp = false;
                val = 900;
            }

            Musik.GetComponent<AudioLowPassFilter>().cutoffFrequency = (val);

        }
        

        if (unDamp && !damp)
        {

            val += 8000f * Time.fixedDeltaTime;
            
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

        HitSFX("b");

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

        a.mute = isMutet;

    }

    public void SFXOnOff()
    {

        HitSFX("b");
        SFXisMutet = !SFXisMutet;

        if (SFXisMutet)
        {
            off1.SetActive(true);
            on1.SetActive(false);
        }
        else
        {
            on1.SetActive(true);
            off1.SetActive(false);
        }

        PlayerPrefs.SetInt("muteSFX", boolToInt(SFXisMutet));

    }

    public void HitSFX(string sound)
    {

        if (!SFXisMutet)
        {

            if(sound == "hitCorrect")
            {
                Instantiate(hit);
            }

            if(sound == "missed")
            {
                Instantiate(Hurt);
            }

            if(sound == "b")
            {
                Instantiate(Bottun);
            }
        }
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

