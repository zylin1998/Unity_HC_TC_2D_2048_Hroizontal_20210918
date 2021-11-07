using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class learnSwitch : MonoBehaviour
{
    //public string equipment;
    public string[] equipments;

    [Range(0,3)]
    public int select; 

    void Start()
    {
        //equipments = new string[3];
        
        /*switch (equipment)
        {

            case "刀子":
                print("正在使用刀子");
                break;
            case "叉子":
                print("正在使用叉子");
                break;
            default:
                print("未使用裝備");
                break;

        }*/
    }

    void Update()
    {
        if (select < 3) { print("正在使用" + equipments[select]); }

        else { print("未使用裝備"); }
    }

}
