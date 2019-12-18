using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PSScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        other.GetComponent<Butterfly>().Damage();
        //Debug.Log("Particle Hit!");
    }

}
