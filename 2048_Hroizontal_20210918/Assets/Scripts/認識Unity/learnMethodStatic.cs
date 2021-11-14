using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learnMethodStatic : MonoBehaviour
{
    public float[] randomNumber;
    
    void Start()
    {
        randomNumber = new float[10];

        Random.InitState(42);

        for(int i = 0; i < randomNumber.Length; i++)
        {
            randomNumber[i] = Random.Range(0.0f, 7.7f);
            print(randomNumber[i]);
        }
                
    }

}
