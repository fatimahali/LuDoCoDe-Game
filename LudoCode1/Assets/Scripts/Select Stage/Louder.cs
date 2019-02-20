using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Louder : MonoBehaviour
{
    public GameObject GameObject;
    public PassNumSteps Script;
 
  
    private void Awake()
    {
        // find Game object with Tage  returns single Game objcte with char the tag 
        // find Game objects with tag return  an array of such Game object 
        GameObject = GameObject.FindGameObjectsWithTag("GameObject")[0] as GameObject;

        // GetComponent loads the PassNumSteps
        Script = GameObject.GetComponent<PassNumSteps>();

      //  txtBox.text = "" + Script.move;
    }
}
