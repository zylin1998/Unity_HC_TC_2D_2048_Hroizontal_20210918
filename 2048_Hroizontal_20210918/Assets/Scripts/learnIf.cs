using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learnIf : MonoBehaviour
{
    public int score = 99;
    public bool isOpenDoor = true;

    // Start is called before the first frame update
    void Start()
    {
        if (isOpenDoor) { print("Bool is True"); }
        
        if (!isOpenDoor) { print("Bool is False"); }
    }

    // Update is called once per frame
    void Update()
    {
        if(score >= 60) { print("及格"); }

        else if(score >= 40) { print("補考"); }

        else { print("死當"); }

    }

}
