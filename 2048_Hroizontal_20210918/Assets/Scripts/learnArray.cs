using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learnArray : MonoBehaviour
{
    public int[] scores;

    public float[] attacks = new float[3];

    public string[] prop = { "¬õ¤ô", "ÂÅ¤ô", "Ä«ªG" };

    void Start()
    {
        for(int i = 0; i < scores.Length; i++) { scores[i] = i * 10 + 10; }
    }

    void Update()
    {
        
    }
}
