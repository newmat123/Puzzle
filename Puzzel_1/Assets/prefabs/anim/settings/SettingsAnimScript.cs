using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsAnimScript : MonoBehaviour
{

    public Animator Settings;

    public void settings(bool i)
    {

        Settings.SetBool("Settings", i);

    }

}
