using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class DisplayPlayer : MonoBehaviour
{
    public PassNumSteps Script;// to pass the object 
    public GameObject NextStage;
    public GameObject PlayerName;
    public GameObject PlayerScore;
    public GameObject PlayerRerolls;
    public GameObject PlayerProfille;
    public GameObject Options;
    Text Name;
    Text Score;
    Text Rerolls;
   
    PlayerClass myPlayer = Database.players.GetPlayer(1);
    PlayerClass UpdateRerolls;
   
    // player Profelle 
    public Text playerNum;
    public Text CurrentStage;
    public Text ExperiencePoints;
    public Text TotalWonMatch;
    public Text TotalPlayedMatch;
    public Text AvailableReRolls;



    int availableHints = 5;
    int playerTokenPosition = 0;
    int ComputerTokenPosition = 0;
    protected  static MatchClass CurrentMatchClass = new MatchClass("4", 5, 0, 0);
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
        //Select stage to access Prompt the player to select stage
   //   if( stage ==  )
            StartCoroutine(Database.Instance.GetExercises(isSuccessful =>
            {
                 StartMatch(stage, myPlayer);

               
                SceneManager.LoadScene("match" + stage);//match 1

            }));

        //else
        //    print("To access this stage you must complete the previous stage");
    

         

       
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
    public void StartMatch(string selectedStage, PlayerClass currentPlayer)
    {
       
        CurrentMatchClass.availableHints = 5;
        CurrentMatchClass.currentStage = "5";
        CurrentMatchClass.playerTokenPosition = 0;
        CurrentMatchClass.ComputerTokenPosition = 0;

        PlayerPrefs.SetInt("playerToken1Position", 0);
        PlayerPrefs.SetInt("playerToken2Position", 0);
        PlayerPrefs.SetInt("ComputerToken1Position", 0);
        PlayerPrefs.SetInt("ComputerToken2Position", 0);

        Debug.Log("Available Rerolls" + myPlayer.AvailableRerolls + ":" + CurrentMatchClass.availableHints);
      //  Script.matchClass = CurrentMatchClass;
        CurrentMatchClass = new MatchClass(selectedStage, availableHints, playerTokenPosition, ComputerTokenPosition);
       
    }

    public void PlayerProfilleMethod()
    {
       PlayerProfille.SetActive(true);
        playerNum.text = myPlayer.Name;
        CurrentStage.text = myPlayer.CurrentStage.ToString();
        ExperiencePoints.text = myPlayer.ExperiencePoints.ToString();
        TotalWonMatch.text = myPlayer.TotalWonMatch.ToString();
        TotalPlayedMatch.text = myPlayer.TotalPlayedMatch.ToString();
        AvailableReRolls.text = myPlayer.AvailableRerolls.ToString();
    }
    public void ExitMethodPlayerProfills()
    {
        PlayerProfille.SetActive(false);
    }

    public void OptionsMethod()
    {
        Options.SetActive(true);
    }
    public void ExitOptionsMethod()
    {
        Options.SetActive(false);
    }
    public void HomeMethod()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
