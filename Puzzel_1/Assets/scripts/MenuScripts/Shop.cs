using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{

    public int MoreHealth = 3;

    public GameObject[] Health;

    public bool[] HealthBuyed = new bool[] {};

    public int[] price = new int[] {};

    [Space(20)]

    int lastbuy = 0;
    public int money;

    [Space(20)]

    public TextMeshProUGUI HealtPriceText;


    public void updateShop()
    {

        for (int i = 0; i < HealthBuyed.Length; i++)
        {

            HealthBuyed[i] = intToBool(PlayerPrefs.GetInt("HealtBool" + i));

            if (HealthBuyed[i] == true)
            {
                Health[i].SetActive(true);

                lastbuy = i + 1;
            }
            else
            {
                Health[i].SetActive(false);
            }

        }

        MoreHealth = 3;
        MoreHealth += lastbuy;

        if(lastbuy >= price.Length)
        {
            HealtPriceText.text = "out of stock";
        }
        else
        {
            HealtPriceText.text = price[lastbuy].ToString();
        }
        
    }


    public void BuyHealt()
    {

        bool buyable = true;
        money = PlayerPrefs.GetInt("myCash");

        if (lastbuy >= price.Length)
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

                    if (lastbuy >= price.Length)
                    {
                        HealtPriceText.text = "out of stock";
                    }
                    else
                    {
                        HealtPriceText.text = price[lastbuy].ToString();
                    }

                    MoreHealth = 3;
                    MoreHealth += lastbuy;

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
        updateShop();
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
