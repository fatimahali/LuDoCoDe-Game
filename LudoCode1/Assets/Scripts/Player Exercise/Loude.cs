using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loude : MonoBehaviour
{
    public Text txtBox;
    public Text Countdown;

    public GameObject GameObject;
    public PassNumSteps Script;
  /*  void Start()
    {
        StartCoroutine(StartCountdown());


    }*/
    private void Awake()
    { 
        // find Game object with Tage  returns single Game objcte with char the tag 
        // find Game objects with tag return  an array of such Game object 
        GameObject = GameObject.FindGameObjectsWithTag("GameObject")[0] as GameObject;

        // GetComponent loads the PassNumSteps
        Script = GameObject.GetComponent<PassNumSteps>();

        txtBox.text =""+ Script.move;
    }
/*    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Countdown.text= "Countdown: " + currCountdownValue;
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
    }*/




}
