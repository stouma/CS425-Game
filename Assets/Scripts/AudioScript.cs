using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource source;

    public AudioClip clip1, clip2, clip3;

    float timePassed;

    // Start is called before the first frame update
    void Start()
    {
        source.clip = clip1;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        if(timePassed >= 60)
        {
            timePassed -= 60;
            if(source.clip == clip1)
            {
                ChangeBGM(clip2);
            }
            else if(source.clip == clip2)
            {
                ChangeBGM(clip3);
            }
        }
    }

    void ChangeBGM(AudioClip music)
    {
        //while (source.volume != 0)
        //{
        //    source.volume -= 0.2f;
        //    new WaitForSeconds(1);
        //}
        source.Stop();

        source.clip = music;

        //while (source.volume != 1)
        //{
        //    source.volume += 0.2f;
        //    new WaitForSeconds(1);
        //}
        source.Play();
    }
}
