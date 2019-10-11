using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopAnimScript : MonoBehaviour
{

    public Animator Shop;

    public void openShop(bool i)
    {
        Shop.SetBool("Shop", i);
    }

}
