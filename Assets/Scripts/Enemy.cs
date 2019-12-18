using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    private AudioSource source;

    float timePassed;
    float xsp, ysp;

    public float xSpeed, ySpeed;
    public float fireRate;
    public float health;
    public bool canShoot;

    public int score;

    public GameObject bullet, heart;

    GameObject temp;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        xsp = Random.Range(-xSpeed, xSpeed);
        ysp = Random.Range(ySpeed, ySpeed+0.4f);

        if (canShoot)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
        //fireRate = fireRate + (Random.Range(fireRate / -2, fireRate / 2));
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        float num = Random.Range(1, 3);
        if(timePassed >= num)
        {
            timePassed -= num;
            xsp *= -1;
        }
        rb.velocity = new Vector2(xsp, ysp*-1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Butterfly>().Damage();
            //Debug.Log("Hit!");
            Die();
        }
    }

    public void Damage()
    {
        health--;
        source.Play();

        if (health == 0)
        {
            Die();
        }
    }

    void Shoot()
    {
        temp = (GameObject) Instantiate(bullet, new Vector3(transform.position.x, transform.position.y-1, transform.position.z), Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
    }

    void Die()
    {
        if ((int)Random.Range(0, 5) == 0)
        {
            Instantiate(heart, transform.position, Quaternion.identity);
        }
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        Destroy(gameObject);
        Destroy(temp);
    }
}
