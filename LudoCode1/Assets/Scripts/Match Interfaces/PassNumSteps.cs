using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassNumSteps : MonoBehaviour
{

   
    private static int availableHints =5;
    private static string currentStage;
    private static int playerTokenPosition;
    private static int ComputerTokenPosition;
    public string move;
    public MatchClass matchClass;//=new MatchClass(currentStage, availableHints, playerTokenPosition, ComputerTokenPosition);
    //internal MatchClass MatchClass;

    private void Awake()
    {
       DontDestroyOnLoad(this);
    }
}
