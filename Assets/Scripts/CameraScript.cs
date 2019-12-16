using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    float timePassed;
    public Color color1, color2, color3;
    private float t = 0 , t2 =0;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
        cam.backgroundColor = color1;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if (timePassed >= 60)
        {
            //timePassed -= 5;
            Color currColor = Color.Lerp(color1, color2, t);
            cam.backgroundColor = currColor;

            if (t < 1)
                t += Time.deltaTime;
        }

        if(timePassed >= 120)
        {
            //timePassed -= 10;
            Color currColor = Color.Lerp(color2, color3, t2);
            cam.backgroundColor = currColor;

            if(t2 < 1)
                t2 += Time.deltaTime;
        }

        //if(t < 5)
        //{
        //    t += Time.deltaTime / 5;
        //}
    }

}

