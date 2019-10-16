using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop : MonoBehaviour
{

    public GameObject[] texts;

    public bool holder1;
    public bool holder2;
    public bool holder3;

    public GameObject[] lockui;
    public GameObject[] ofs;

    public int HealthPowerup = 3;
    public int MoreHealth = 3;
    public int SlowmoTime = 0;
    public bool isSlowmoActive = false;

    public GameObject[] Health;
    public GameObject[] Slowmo;
    public GameObject[] HPowerup;

    public bool[] HealthBuyed = new bool[] {};
    public bool[] SlowmoBuyed = new bool[] {};
    public bool[] HealthPoweupBuyed = new bool[] { };

    public int[] HealthPrice = new int[] {};
    public int[] SlowmoPrice = new int[] {};
    public int[] HealthPoweupPrice = new int[] { };

    [Space(20)]

    int multiplayer = 3;
    int lastbuyHealth = 0;
    int lastbuySlowmo = 0;
    int lastbuyHealthPowerup = 0;
    public int money;

    [Space(20)]

    public TextMeshProUGUI HealtPriceText;
    public TextMeshProUGUI SlowmoPriceText;
    public TextMeshProUGUI HealtPowerupPriceText;


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
        MoreHealth += 2 * lastbuyHealth;

        if(lastbuyHealth >= HealthPrice.Length)
        {
            HealtPriceText.text = "out of stock";
            ofs[0].SetActive(true);
        }
        else
        {
            HealtPriceText.text = HealthPrice[lastbuyHealth].ToString();
            ofs[0].SetActive(false);
        }


        //HealthPowerup

        for (int i = 0; i < HealthPoweupBuyed.Length; i++)
        {

            HealthPoweupBuyed[i] = intToBool(PlayerPrefs.GetInt("HealthPowerupBool" + i));

            if (HealthPoweupBuyed[i] == true)
            {
                HPowerup[i].SetActive(true);

                lastbuyHealthPowerup = i + 1;
            }
            else
            {
                HPowerup[i].SetActive(false);
            }
        }

        HealthPowerup = 3;
        HealthPowerup += lastbuyHealthPowerup;

        if (lastbuyHealthPowerup >= HealthPoweupPrice.Length)
        {
            HealtPowerupPriceText.text = "out of stock";
            ofs[2].SetActive(true);
        }
        else
        {
            HealtPowerupPriceText.text = HealthPoweupPrice[lastbuyHealthPowerup].ToString();
            ofs[2].SetActive(false);
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

        SlowmoTime = 0;
        SlowmoTime += lastbuySlowmo * multiplayer;

        if (lastbuySlowmo >= SlowmoPrice.Length)
        {
            SlowmoPriceText.text = "out of stock";
            ofs[1].SetActive(true);
        }
        else
        {
            SlowmoPriceText.text = SlowmoPrice[lastbuySlowmo].ToString();
            ofs[1].SetActive(false);
        }

        chekSlow();

    }

    public void chekSlow()
    {
        if (SlowmoBuyed[0] == true)
        {
            lockui[0].SetActive(false);
            isSlowmoActive = true;
            holder1 = true;

            if (SlowmoBuyed[2] == true)
            {
                holder2 = true;
                if (SlowmoBuyed[5] == true)
                {
                    holder3 = true;
                }
                else
                {
                    holder3 = false;
                }
            }
            else
            {
                holder2 = false;
                holder3 = false;
            }
        }
        else
        {
            lockui[0].SetActive(true);
            isSlowmoActive = false;
            holder1 = false;
            holder2 = false;
            holder3 = false;
        }
    }

    public void BuyHealt()
    {

        FindObjectOfType<SoundManeger>().HitSFX("b");
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
                        ofs[0].SetActive(true);
                    }
                    else
                    {
                        HealtPriceText.text = HealthPrice[lastbuyHealth].ToString();
                        ofs[0].SetActive(false);
                    }

                    MoreHealth = 3;
                    MoreHealth += lastbuyHealth;

                    Instantiate(texts[0]).transform.parent = gameObject.transform;

                }
            }
        }
    }


    public void BuyMoreSlowmoTime()
    {

        FindObjectOfType<SoundManeger>().HitSFX("b");
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

                    isSlowmoActive = true;
                    lastbuySlowmo++;

                    if (lastbuySlowmo >= SlowmoPrice.Length)
                    {
                        SlowmoPriceText.text = "out of stock";
                        ofs[1].SetActive(true);
                    }
                    else
                    {
                        SlowmoPriceText.text = SlowmoPrice[lastbuySlowmo].ToString();
                        ofs[1].SetActive(false);
                    }

                    SlowmoTime = 0;
                    SlowmoTime += lastbuySlowmo * multiplayer;
                    chekSlow();

                    Instantiate(texts[2]).transform.parent = gameObject.transform;

                }
            }
        }
    }


    public void BuyMoreHealthPowerup()
    {

        FindObjectOfType<SoundManeger>().HitSFX("b");
        bool buyable = true;
        money = PlayerPrefs.GetInt("myCash");

        if (lastbuyHealthPowerup >= HealthPoweupPrice.Length)
        {
            buyable = false;
        }

        if (buyable)
        {

            if (money >= HealthPoweupPrice[lastbuyHealthPowerup])
            {

                if (lastbuyHealthPowerup < HealthPoweupPrice.Length)
                {

                    HPowerup[lastbuyHealthPowerup].SetActive(true);
                    HealthPoweupBuyed[lastbuyHealthPowerup] = true;

                    money -= HealthPoweupPrice[lastbuyHealthPowerup];

                    PlayerPrefs.SetInt("myCash", money);

                    FindObjectOfType<ScoreScript>().updateText();

                    for (int i = 0; i < HealthPoweupBuyed.Length; i++)
                    {

                        PlayerPrefs.SetInt("HealthPowerupBool" + i, boolToInt(HealthPoweupBuyed[i]));

                    }

                    lastbuyHealthPowerup++;

                    if (lastbuyHealthPowerup >= HealthPoweupPrice.Length)
                    {
                        HealtPowerupPriceText.text = "out of stock";
                        ofs[2].SetActive(true);
                    }
                    else
                    {
                        HealtPowerupPriceText.text = HealthPoweupPrice[lastbuyHealthPowerup].ToString();
                        ofs[2].SetActive(false);
                    }

                    HealthPowerup = 3;
                    HealthPowerup += lastbuyHealthPowerup;

                    Instantiate(texts[1]).transform.parent = gameObject.transform;

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
        for (int i = 0; i < HealthPoweupBuyed.Length; i++)
        {

            HealthPoweupBuyed[i] = false;

            PlayerPrefs.SetInt("HealthPowerupBool" + i, boolToInt(HealthPoweupBuyed[i]));
        }
        updateShop();

        float k = 0;
        PlayerPrefs.SetFloat("savedRecord", k);
        PlayerPrefs.Save();

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
