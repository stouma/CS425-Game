using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    private AudioSource source;
    int dir = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void ChangeDirection()
    {
        dir *= -1;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 6 * dir);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        source.Play();
        

        if (dir == 1)
        {
            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<Enemy>().Damage();
                Destroy(gameObject);
            }
    }
        else
        {
            if (col.gameObject.tag == "Player")
            {
                col.gameObject.GetComponent<Butterfly>().Damage();
                //Debug.Log("Hit!");
                Destroy(gameObject);
            }
        }
    }

}
