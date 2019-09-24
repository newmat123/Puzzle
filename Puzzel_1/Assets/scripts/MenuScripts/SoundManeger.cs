using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManeger : MonoBehaviour
{

    public bool isMutet = false;

    public GameObject on;
    public GameObject off;

    public GameObject Musik;



    private void Start()
    {

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

