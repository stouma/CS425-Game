using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;

    private AudioSource source;

    public float xSpeed, ySpeed;
    public float fireRate;
    public float health;
    public bool canShoot;

    public GameObject bullet;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Destroy(gameObject, 10);

        if (canShoot)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
        //fireRate = fireRate + (Random.Range(fireRate / -2, fireRate / 2));
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed*-1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<Butterfly>().Damage();
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
        GameObject temp = (GameObject) Instantiate(bullet, new Vector3(transform.position.x, transform.position.y+2, transform.position.z), Quaternion.identity);
        temp.GetComponent<Bullet>().ChangeDirection();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
