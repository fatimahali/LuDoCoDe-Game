using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DisplayPlayer : MonoBehaviour
{
    
    public static string server = "http://ludo-code.com";
    public static string path = "/";


    public GameObject PlayerName;
    public GameObject PlayerScore;
    public GameObject PlayerRerolls;

    Text Name;
    Text Score;
    Text Rerolls;

    public PlayerClass myPlayer = Database.players.GetPlayer(1);
    PlayerClass UpdateRerolls; 

    // Start is called before the first frame update
    void Start()
    {
        //PlayerClass myPlayer = Database.players.GetPlayer(1);
         
        if (myPlayer!= null)
        {
            PlayerName = GameObject.Find("Name");
            PlayerScore = GameObject.Find("Score");
            PlayerRerolls = GameObject.Find("ReRolls");

            Name = PlayerName.GetComponent<Text>();
            Score = PlayerScore.GetComponent<Text>();
            Rerolls = PlayerRerolls.GetComponent<Text>();

            Debug.Log(myPlayer.Name + " : " + myPlayer.ExperiencePoints);

            Name.text = myPlayer.Name;
            Score.text = myPlayer.ExperiencePoints.ToString();
            Rerolls.text = myPlayer.AvailableRerolls.ToString();
        }
        else 
            Debug.Log("Error");

    }
    public void SelectStag (string stage)
    {
        SceneManager.LoadScene("match" + stage);//match 1
    }
    public void AvailableRerolls(string stage)
    {

        int AvailableReroll = myPlayer.AvailableRerolls;
       // int id = myPlayer.Id;
       int CurrentStage = myPlayer.CurrentStage;

        if (AvailableReroll >= 0)
        {
            AvailableReroll--;// Decreasing currentPlayer.availableReRolls by one
            Debug.Log(AvailableReroll);
            //   StartCoroutine(Database.Instance.UpdatePlayer(new PlayerClass(1,1, AvailableReroll)), isSuccessful =>
            //  {
            //     ShowPlayers();
            //   ps = Database.players;
            //  }); 
            UpdateRerolls = Database.players.UseAvailableRerolls(1, CurrentStage, AvailableReroll);
            SceneManager.LoadScene("match" + stage);  // Call (currentMatch)
            Debug.Log("new AvailableReroll" + myPlayer.AvailableRerolls);
        }

        
    }
    public void StartMatch(StageClass selectedStage, PlayerClass currentPlayer)
    {
       //  MatchClass  currentMatchClass =;


    }






    // Update is called once per frame
    void Update()
    {
        
    }
}
