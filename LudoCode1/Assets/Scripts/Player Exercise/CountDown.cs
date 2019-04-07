using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class CountDown : MonoBehaviour
{
    public Image fillImg;
    private readonly float  timeAmt = 10;
    float time;
    // public Text timeText;
    public GameObject TimeUP;
    // Use this for initialization
    void Start()
    {
        fillImg = GetComponent<Image>();
        time = timeAmt;
    }

   

    // Update is called once per frame
    void Update()
    {
        if (time > 0)

        {
            time -= Time.deltaTime;

            fillImg.fillAmount = time / timeAmt;
         
        }
        else
        {
            TimeUP.SetActive(true);
            // Pause before next itteration
          
            MoveToMacth();
           SceneManager.LoadScene(4);
        }
    }

    private IEnumerator MoveToMacth()
    {
        yield return new WaitForSeconds(0.56f);
        
    }
}
