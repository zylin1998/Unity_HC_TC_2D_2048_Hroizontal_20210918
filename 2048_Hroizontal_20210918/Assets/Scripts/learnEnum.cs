using System;
using UnityEngine;

public class learnEnum : MonoBehaviour
{
    [Flags]
    public enum EnemyState {
    
        Idle = 0,
        Walk = 1, 
        Track = 2, 
        Attack = 4,
        Dead = 8
    
    }

    public EnemyState enemyState;
    
    [Range(0,15)]
    public int state = 0;

    private void Start()
    {
    }

    private void Update()
    {
        print("Now state is " + (EnemyState)state);
    }
}
