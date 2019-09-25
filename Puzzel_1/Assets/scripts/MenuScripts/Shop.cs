using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject[] Health;

    public bool[] HealthBuyed = new bool[] {false, false};

    public int money;
    public int[] price = new int[] {100, 200};

    int lastbuy = 0;

    void Start()
    {

        for (int i = 0; i < HealthBuyed.Length; i++)
        {

            HealthBuyed[i] = intToBool(PlayerPrefs.GetInt("HealtBool"+ i));

            if(HealthBuyed[i] == true)
            {
                Health[i].SetActive(true);

                lastbuy = i+1;
            }
            else
            {
                Health[i].SetActive(false);
            }

        }

    }



    public void BuyHealt()
    {
        bool buyable = true;
        money = PlayerPrefs.GetInt("myCash");

        if(lastbuy >= price.Length)
        {
            buyable = false;
        }


        if (buyable)
        {

            if(money >= price[lastbuy])
            {

                if(lastbuy < price.Length)
                {

                    Health[lastbuy].SetActive(true);
                    HealthBuyed[lastbuy] = true;

                    money -= price[lastbuy];

                    PlayerPrefs.SetInt("myCash", money);

                    FindObjectOfType<ScoreScript>().updateText();

                    for(int i = 0; i < HealthBuyed.Length; i++)
                    {

                        PlayerPrefs.SetInt("HealtBool" + i , boolToInt(HealthBuyed[i]));

                    }

                    lastbuy++;
                }

            }

        }

    }

    public void gggg()
    {
        for (int i = 0; i < HealthBuyed.Length; i++)
        {

            HealthBuyed[i] = false;

            PlayerPrefs.SetInt("HealtBool" + i, boolToInt(HealthBuyed[i]));
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
