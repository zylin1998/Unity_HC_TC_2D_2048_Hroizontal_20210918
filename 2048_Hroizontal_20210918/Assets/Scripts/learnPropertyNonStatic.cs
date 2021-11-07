using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learnPropertyNonStatic : MonoBehaviour
{
    public Camera camera;

    void Start()
    {
        print("The depth of Camera is " + camera.depth);
    }
}
