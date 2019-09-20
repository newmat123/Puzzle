using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject[] Enemys;

    [Space(20)]

    public GameObject Arrow;
    List<GameObject> ArrowToDelete = new List<GameObject>();

    [Space(20)]

    public Vector3 spawnValues;
    public float spawnWait;
    public float SpecialSpawnWait;

    public int startWait;
    public float A;

    private float specialTimer;
    private float timer;
    private float timerB;

    private float ArrowTimer;

    public void startWaiter()
    {

        SpecialSpawnWait = Random.Range(5, 10);
        specialTimer = 0;

        StartCoroutine(WaitSpawner());
        timerB = 0;
        spawnWait = 2;

    }

    void Update()
    {

        specialTimer += Time.deltaTime;

        if (specialTimer > SpecialSpawnWait)
        {

            SpawnCharger();
            
            SpecialSpawnWait = Random.Range(15, 50);

            specialTimer = 0;

        }

    }

    public void SpawnCharger()
    {
        ArrowTimer = 0;

        Vector3 spawnPoinrt = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Vector3 arrowpos = new Vector3(spawnPoinrt.x, 2, 0);

        ArrowToDelete.Add(Instantiate(Arrow, arrowpos, Quaternion.Euler(new Vector3(0, 0, 90))));
        
        while(ArrowTimer < 3)
        {

            ArrowTimer += Time.deltaTime;
            if (ArrowTimer >= 3)
            {
                Instantiate(Enemys[1], spawnPoinrt + transform.TransformPoint(0, 0, 0), transform.rotation);
                Destroy(ArrowToDelete[0]);
                ArrowToDelete = new List<GameObject>();
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

