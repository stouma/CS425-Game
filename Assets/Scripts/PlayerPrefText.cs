using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefText : MonoBehaviour
{
    public string name;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = PlayerPrefs.GetInt(name) + "";
    }
}
