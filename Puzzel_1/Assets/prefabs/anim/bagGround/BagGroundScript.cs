using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagGroundScript : MonoBehaviour
{

    public Animator Bag;


    public void fadeBagground(bool i)
    {

        Bag.SetBool("Fade", i);

    }

}
