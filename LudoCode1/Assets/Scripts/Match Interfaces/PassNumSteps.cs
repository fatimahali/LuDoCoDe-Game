using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassNumSteps : MonoBehaviour
{
    public string move;


    private void Awake()
    {
        // 
        DontDestroyOnLoad(this);
    }
}
