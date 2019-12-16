using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float rate;
    public GameObject[] enemies;
    public int waves = 1;
    float timePassed, t, elapsedTime;
    int enemytype = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    void SpawnEnemy()
    {
        elapsedTime += Time.deltaTime;

        for (int i = 0; i < waves; i++)
        {
            //Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-4.5f, 4.5f), 4, 0), Quaternion.identity);
            Instantiate(enemies[enemytype], new Vector3(Random.Range(-4.5f, 4.5f), 5, 0), Quaternion.identity);
        }

    }

    void Update()
    {
        timePassed += Time.deltaTime;
        t += Time.deltaTime;

        if(t >= 60)
        {
            t -= 60;
            waves = 1;
            if(enemytype < enemies.Length)
                enemytype++;
        }

        if (timePassed >= 10 && waves <= 3 && enemytype != 2)
        {
            Debug.Log(waves);
            timePassed -= 10;
            waves++;
        }

        if (timePassed >= 10 && waves <= 2 && enemytype == 2)
        {
            Debug.Log(waves);
            timePassed -= 10;
            waves++;
        }
    }
}
