using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mixer : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource SFX;


    void Start()
    {
        BGM.GetComponent<AudioSource>();
        SFX.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
