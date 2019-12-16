using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    public ParticleSystem ps;
    float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "Clouds")
        {
            ps.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if(timePassed >= 60 && gameObject.tag == "Clouds")
        {
            ps.Clear();
        }
        if(timePassed >= 60 && gameObject.tag == "Sand")
        {
            ps.Play();
        }
        if(timePassed >= 120 && gameObject.tag == "Sand")
        {
            ps.Stop();
        }
        if(timePassed >= 120 && gameObject.tag == "Snow")
        {
            ps.Play();
        }
    }
}
