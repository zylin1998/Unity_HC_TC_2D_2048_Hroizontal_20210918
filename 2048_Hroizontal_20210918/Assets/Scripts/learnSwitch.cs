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

            case "�M�l":
                print("���b�ϥΤM�l");
                break;
            case "�e�l":
                print("���b�ϥΤe�l");
                break;
            default:
                print("���ϥθ˳�");
                break;

        }*/
    }

    void Update()
    {
        if (select < 3) { print("���b�ϥ�" + equipments[select]); }

        else { print("���ϥθ˳�"); }
    }

}
