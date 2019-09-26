using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject[] Enemys;

    [Space(20)]

    public GameObject Arrow;
    private bool spawned = false;

    [Space(20)]

    public Vector3 spawnValues;
    public float spawnWait;
    public float SpecialSpawnWait;

    public int startWait;
    public float A;


    //----------------------------------------------------------------


    private int Xmax = 40;
    private int XmaxMin = 8;
    private int Xmin = 10;
    private int XminMin = 2;


    private float timer;
    private float timerB;

    private float ArrowTimer;
    private float timeTo;

    private Vector3 spawnPoinrt2;
    private Vector3 arrowpos;

    //-------------------------------------------------------------

    public void startWaiter()
    {
        Xmin = 10;
        Xmax = 40;

        SpecialSpawnWait = Random.Range(10, 25);

        StartCoroutine(WaitSpawner());
        timerB = 0;
        spawnWait = 2;

    }

    void Update()
    {
        if (FindObjectOfType<ScoreScript>().gameactive == true)
        {

            ArrowTimer += Time.deltaTime;
            if (ArrowTimer > SpecialSpawnWait)
            {

                if (spawned == false)
                {

                    spawnPoinrt2 = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z - 0.5f);
                    arrowpos = new Vector3(spawnPoinrt2.x, 2, -1f);

                    Instantiate(Arrow, arrowpos, Quaternion.Euler(new Vector3(0, 0, 90)));
                    timeTo = 0;
                    spawned = true;

                }
                else if (spawned)
                {

                    timeTo += Time.deltaTime;

                    if (timeTo >= 2)
                    {

                        int i;

                        if (FindObjectOfType<Shop>().isSlowmoActive == true)
                        {
                            i = Random.Range(1, Enemys.Length);
                        }
                        else
                        {
                            i = Random.Range(1, Enemys.Length-1);
                        }

                        

                        Instantiate(Enemys[i], spawnPoinrt2 + transform.TransformPoint(0, 0, 0), transform.rotation);
                        spawned = false;
                        SpecialSpawnWait = Random.Range(Xmin, Xmax);
                        ArrowTimer = 0;

                        if (Xmax > XmaxMin)
                        {

                            Xmax -= 4;

                        }
                        else
                        {
                            Xmax = XmaxMin;
                        }


                        if (Xmin > XminMin)
                        {
                            Xmin -= 2;
                        }
                        else
                        {
                            Xmin = XminMin;
                        }

                    }

                }

            }

        }
        else
        {
            ArrowTimer = 0;
            timeTo = 0;
            spawned = false;
        }

    }

    

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {

            timer += Time.deltaTime;
            timerB += Time.deltaTime;

            if (timer >= spawnWait)
            {

                Vector3 spawnPoinrt = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

                Instantiate(Enemys[0], spawnPoinrt + transform.TransformPoint(0, 0, 0), transform.rotation);

                yield return new WaitForSeconds(spawnWait);

                timer = 0;

                if (spawnWait > 0.10f)
                {

                    spawnWait = A / Mathf.Sqrt(timerB);
                    if (spawnWait > 2)
                    {

                        spawnWait = 2;

                    }

                }
                else
                {
                    spawnWait = 0.10f;
                }

            }

        }

    }

}

