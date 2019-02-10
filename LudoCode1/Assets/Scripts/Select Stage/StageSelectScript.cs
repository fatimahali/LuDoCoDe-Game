using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectScript : MonoBehaviour
{



    private int StageIndex;
    public static int Stages = 6;
    public GameObject NextStage;
    //public GameObject PlayerName;

    public Text Name;


    // Use this for initialization
    void Start()
    {

        CheckLockedStages();


    }


    //stage to load on button click. Will be used for Level button click event
    public void SelectStage(string stage)
    {

        SceneManager.LoadScene("Stage" + stage);
    }

    void CheckLockedStages()
    {

        int curreStage = 4;
        //loop through the stages
        for (int j = 1; j <= Stages; j++)
        {
            StageIndex = (j + 1);
            if (j <= (curreStage))
            {

                NextStage = GameObject.Find("LockedStage" + (StageIndex));
                NextStage.gameObject.SetActive(false);

                Debug.Log("Unlocked stage " + StageIndex);

            }
            else
            {
                Debug.Log("locked stage " + StageIndex);
                NextStage.SetActive(true);
            }
        }

    }

  
}


