using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learnLoop : MonoBehaviour
{
    public int number = 1;
    
    void Start()
    {

        while (true) {

            print(number);
            number++;

            if (number == 6) { break; }
        
        }

        for(int i = number; i > 0; i--) { print(i); }

    }

}
