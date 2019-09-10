using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtBar : MonoBehaviour
{

    private Transform bar;

    private void Start()
    {
        bar = transform.Find("bar");

    }

    public void SetSize(float sizeNormelised)
    {

        bar.localScale = new Vector3(sizeNormelised, 1f);

    }

}
