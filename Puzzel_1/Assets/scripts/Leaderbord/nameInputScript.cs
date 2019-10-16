using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class nameInputScript : MonoBehaviour
{

    public string theName;
    public GameObject inputField;
    public TextMeshProUGUI nameInput;


    private int isNameInteredBefore = 0;

    private void Start()
    {

        theName = PlayerPrefs.GetString("theName");
        isNameInteredBefore = PlayerPrefs.GetInt("nameBool");
        inputField.SetActive(false);

        openInputField();
    }

    private void Update()
    {
        if (isNameInteredBefore == 0)
        {

            theName = nameInput.text;

        }
    }

    public void openInputField()
    {
        if(isNameInteredBefore == 0)
        {

            inputField.SetActive(true);

        }
    }

    public void closeInputfield()
    {

        if(theName.Length > 1)
        {

            inputField.SetActive(false);

            isNameInteredBefore = 1;
            PlayerPrefs.SetString("theName", theName);
            PlayerPrefs.SetInt("nameBool", isNameInteredBefore);
            PlayerPrefs.Save();

        }

    }


    //bare til at teste med
    public void resteall()
    {
        theName = "";
        isNameInteredBefore = 0;

        PlayerPrefs.SetString("theName", theName);
        PlayerPrefs.SetInt("nameBool", isNameInteredBefore);
        PlayerPrefs.Save();

    }

}
