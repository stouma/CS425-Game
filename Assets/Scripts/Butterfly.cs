using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    private AudioSource source;

    GameObject bullet;
    public GameObject projectile, explosion;
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
        PlayerPrefs.SetInt("Health", health);
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
        PlayerPrefs.SetInt("Health", health);
        source.Play();
        //Debug.Log("Hit!");
        StartCoroutine(Blink());

        if (health == 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = Color.black;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    void Shoot()
    {
        delay = 0;
        Instantiate(projectile, bullet.transform.position, Quaternion.identity);
    }

    public void AddHealth()
    {
        health++;
        PlayerPrefs.SetInt("Health", health);
    }
}
