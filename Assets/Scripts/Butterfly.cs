using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    private AudioSource source;

    GameObject bullet;
    public GameObject projectile;
    Rigidbody2D rb;
    public float speed;
    int health = 3;
    int delay = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bullet = transform.Find("bullet").gameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal")*speed,0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical")*speed));

        if (Input.GetKey(KeyCode.Space)&&delay>10)
        {
            Shoot();
        }

        delay++;
    }

    public void Damage()
    {
        health--;
        source.Play();

        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {
        delay = 0;
        Instantiate(projectile, bullet.transform.position, Quaternion.identity);
    }
}
