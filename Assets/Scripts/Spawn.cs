using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float rate;
    public GameObject[] enemies;
    public int waves = 1;
    float timePassed, t;
    int enemytype = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);
    }

    void SpawnEnemy()
    {

        for (int i = 0; i < waves; i++)
        {
            //Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-4.5f, 4.5f), 7, 0), Quaternion.identity);
            Instantiate(enemies[enemytype], new Vector3(Random.Range(-4.5f, 4.5f), 7, 0), Quaternion.identity);
        }

    }

    void Update()
    {
        timePassed += Time.deltaTime;
        t += Time.deltaTime;

        if(t >= 10)
        {
            t -= 10;
            waves = 1;
            if(enemytype < 2)
                enemytype++;
        }

        if (timePassed >= 10 && waves <= 3)
        {
            Debug.Log(waves);
            timePassed -= 10;
            waves++;
        }
    }
}
