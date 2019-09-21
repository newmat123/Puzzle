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
    public float SpecialSpawnWaitStart;

    public int startWait;
    public float A;

    private float timer;
    private float timerB;

    private float ArrowTimer;



    Vector3 spawnPoinrt;
    Vector3 arrowpos;

    public void startWaiter()
    {

        SpecialSpawnWaitStart = Random.Range(5, 10);

        StartCoroutine(SpawnCharger());
        StartCoroutine(WaitSpawner());
        timerB = 0;
        spawnWait = 2;

    }

    void Update()
    {

 

    }

    

    IEnumerator SpawnCharger()
    {

        yield return new WaitForSeconds(SpecialSpawnWaitStart);

        if(spawned == false)
        {

            spawnPoinrt = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            arrowpos = new Vector3(spawnPoinrt.x, 2, 0);

            Instantiate(Arrow, arrowpos, Quaternion.Euler(new Vector3(0, 0, 90)));
            ArrowTimer = 0;
            spawned = true;

        }

        while(spawned == true)
        {

            ArrowTimer += Time.deltaTime;

            if (ArrowTimer >= 3)
            {

                Instantiate(Enemys[1], spawnPoinrt + transform.TransformPoint(0, 0, 0), transform.rotation);
                
                yield return new WaitForSeconds(SpecialSpawnWait);


                SpecialSpawnWait = Random.Range(5, 10);
                spawned = false;

            }

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

