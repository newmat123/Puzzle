using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{

    public GameObject[] lockui;

    public int MoreHealth = 3;

    public GameObject[] Health;
    public GameObject[] Slowmo;

    public bool[] HealthBuyed = new bool[] {};
    public bool[] SlowmoBuyed = new bool[] {};

    public int[] HealthPrice = new int[] {};
    public int[] SlowmoPrice = new int[] {};

    [Space(20)]

    int lastbuyHealth = 0;
    int lastbuySlowmo = 0;
    public int money;

    [Space(20)]

    public TextMeshProUGUI HealtPriceText;
    public TextMeshProUGUI SlowmoPriceText;


    public void updateShop()
    {

        //health

        for (int i = 0; i < HealthBuyed.Length; i++)
        {

            HealthBuyed[i] = intToBool(PlayerPrefs.GetInt("HealtBool" + i));

            if (HealthBuyed[i] == true)
            {
                Health[i].SetActive(true);

                lastbuyHealth = i + 1;
            }
            else
            {
                Health[i].SetActive(false);
            }

        }

        MoreHealth = 3;
        MoreHealth += lastbuyHealth;

        if(lastbuyHealth >= HealthPrice.Length)
        {
            HealtPriceText.text = "out of stock";
        }
        else
        {
            HealtPriceText.text = HealthPrice[lastbuyHealth].ToString();
        }





        //slowmo

        for (int i = 0; i < SlowmoBuyed.Length; i++)
        {

            SlowmoBuyed[i] = intToBool(PlayerPrefs.GetInt("SlowmoBool" + i));

            if (SlowmoBuyed[i] == true)
            {
                Slowmo[i].SetActive(true);

                lastbuySlowmo = i + 1;
            }
            else
            {
                Slowmo[i].SetActive(false);
            }

        }


        if (lastbuySlowmo >= SlowmoPrice.Length)
        {
            SlowmoPriceText.text = "out of stock";
        }
        else
        {
            SlowmoPriceText.text = SlowmoPrice[lastbuySlowmo].ToString();
        }

        if(SlowmoBuyed[0] == true)
        {
            lockui[0].SetActive(false);
        }
        else
        {
            lockui[0].SetActive(true);
        }

    }


    public void BuyHealt()
    {

        bool buyable = true;
        money = PlayerPrefs.GetInt("myCash");

        if (lastbuyHealth >= HealthPrice.Length)
        {
            buyable = false;
        }

        if (buyable)
        {

            if(money >= HealthPrice[lastbuyHealth])
            {

                if(lastbuyHealth < HealthPrice.Length)
                {

                    Health[lastbuyHealth].SetActive(true);
                    HealthBuyed[lastbuyHealth] = true;

                    money -= HealthPrice[lastbuyHealth];

                    PlayerPrefs.SetInt("myCash", money);

                    FindObjectOfType<ScoreScript>().updateText();

                    for(int i = 0; i < HealthBuyed.Length; i++)
                    {

                        PlayerPrefs.SetInt("HealtBool" + i , boolToInt(HealthBuyed[i]));

                    }

                    lastbuyHealth++;

                    if (lastbuyHealth >= HealthPrice.Length)
                    {
                        HealtPriceText.text = "out of stock";
                    }
                    else
                    {
                        HealtPriceText.text = HealthPrice[lastbuyHealth].ToString();
                    }

                    MoreHealth = 3;
                    MoreHealth += lastbuyHealth;

                }

            }

        }

    }


    public void BuyMoreSlowmoTime()
    {

        bool buyable = true;
        money = PlayerPrefs.GetInt("myCash");

        if (lastbuySlowmo >= SlowmoPrice.Length)
        {
            buyable = false;
        }

        if (buyable)
        {

            if (money >= SlowmoPrice[lastbuySlowmo])
            {

                if (lastbuySlowmo < SlowmoPrice.Length)
                {

                    lockui[0].SetActive(false);

                    Slowmo[lastbuySlowmo].SetActive(true);
                    SlowmoBuyed[lastbuySlowmo] = true;

                    money -= SlowmoPrice[lastbuySlowmo];

                    PlayerPrefs.SetInt("myCash", money);

                    FindObjectOfType<ScoreScript>().updateText();

                    for (int i = 0; i < SlowmoBuyed.Length; i++)
                    {

                        PlayerPrefs.SetInt("SlowmoBool" + i, boolToInt(SlowmoBuyed[i]));

                    }

                    lastbuySlowmo++;

                    if (lastbuySlowmo >= SlowmoPrice.Length)
                    {
                        SlowmoPriceText.text = "out of stock";
                    }
                    else
                    {
                        SlowmoPriceText.text = SlowmoPrice[lastbuySlowmo].ToString();
                    }
                    
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
        for (int i = 0; i < SlowmoBuyed.Length; i++)
        {

            SlowmoBuyed[i] = false;

            PlayerPrefs.SetInt("SlowmoBool" + i, boolToInt(SlowmoBuyed[i]));
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
