using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject[] Enemys;

    public Vector3 spawnValues;
    public float spawnWait;
    public int startWait;
    public float A;

    private float timer;
    private float timerB;
    int randEnemy;

    void Start()
    {


    }

    public void startWaiter()
    {

        StartCoroutine(WaitSpawner());
        timerB = 0;
        spawnWait = 2;

    }

    void Update()
    {

      
        
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
                randEnemy = Random.Range(0, Enemys.Length);

                Vector3 spawnPoinrt = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

                Instantiate(Enemys[randEnemy], spawnPoinrt + transform.TransformPoint(0, 0, 0), transform.rotation);

                yield return new WaitForSeconds(spawnWait);

                timer = 0;
                if (spawnWait > 0.15f)
                {

                    spawnWait = A / Mathf.Sqrt(timerB);
                    if (spawnWait > 2)
                    {

                        spawnWait = 2;

                    }

                }
                else
                {
                    spawnWait = 0.15f;
                }

            }

        }

    }

}

