using UnityEngine;

public class learnProperty1 : MonoBehaviour
{
    public int cameraCount;
    
    void Start()
    {
        cameraCount = Camera.allCamerasCount;
        print("We got " + cameraCount + " camera.");
    }

}
