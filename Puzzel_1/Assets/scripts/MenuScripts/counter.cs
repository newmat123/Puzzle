using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class counter : MonoBehaviour
{

    public GameObject[] numbers;
    List<GameObject> numberToDelete = new List<GameObject>();
    Vector3 pos = new Vector3(0,0,0);

    float timer = 0;
    int timeTo = 0;
    int i = 0;


    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeTo)
        {
            if(i < numbers.Length)
            {

                numberToDelete.Add(Instantiate(numbers[i], pos, transform.rotation));

                timeTo += 1;

                i++;
            }
            
        }

        if(numberToDelete.Count > 1)
        {

            Destroy(numberToDelete[0]);

            if (numberToDelete.Count > 2)
            {

                Destroy(numberToDelete[1]);

                if (timer >= 3)
                {

                    Destroy(numberToDelete[2]);

                    timeTo = 0;
                    i = 0;
                    numberToDelete = new List<GameObject>();
                    timer = 0;

                    FindObjectOfType<ScoreScript>().afterCount();


                }

            }

        }
        
    }

}
