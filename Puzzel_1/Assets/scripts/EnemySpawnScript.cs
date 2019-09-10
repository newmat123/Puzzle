using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{

    public GameObject[] Enemys;

    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnM;
    public float spawnL;
    public int startWait;

    int randEnemy;

    void Start()
    {

        StartCoroutine(WaitSpawner());

    }

    // Update is called once per frame
    void Update()
    {

        spawnWait = Random.Range(spawnL, spawnM);

    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {

            randEnemy = Random.Range(0, Enemys.Length);

            Vector3 spawnPoinrt = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

            Instantiate(Enemys[randEnemy], spawnPoinrt + transform.TransformPoint(0,0,0), transform.rotation);

            yield return new WaitForSeconds(spawnWait);

        }


    }

}

