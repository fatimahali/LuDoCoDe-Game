using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
   public Image fillImg;
    private readonly int  timeAmt = 500;
    int time;
    public Text timeText;

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
            time --;

            fillImg.fillAmount = time / timeAmt;
            timeText.text =  time.ToString();
        }
    }
}
