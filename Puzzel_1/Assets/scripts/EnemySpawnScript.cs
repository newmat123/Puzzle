using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject[] Enemys;

    public Vector3 spawnValues;
    public float spawnWait;
    public int startWait;

    private float timer;
    int randEnemy;

    void Start()
    {


    }

    public void startWaiter()
    {

        StartCoroutine(WaitSpawner());

    }

    void Update()
    {

        //spawnWait = Random.Range(spawnL, spawnM);

    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            timer += Time.deltaTime;

            if (timer >= spawnWait)
            {
                randEnemy = Random.Range(0, Enemys.Length);

                Vector3 spawnPoinrt = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

                Instantiate(Enemys[randEnemy], spawnPoinrt + transform.TransformPoint(0, 0, 0), transform.rotation);

                yield return new WaitForSeconds(spawnWait);
                timer = 0;
                spawnWait += Mathf.Sqrt(Time.deltaTime);

            }

        }


    }

}

