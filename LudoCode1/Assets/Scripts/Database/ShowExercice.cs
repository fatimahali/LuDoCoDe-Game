using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class ShowExercice : MonoBehaviour
{

    List<string> HintsExercice = Database.hints.GetHints(1);// currentExercise
    ExerciseClass Exer = Database.exercises.GetEexrcise(1);
    Random rnd = new Random();
   public int hint;
    public int numofhints = 5;
    public Text Exercise;
    public GameObject Displayhint;
    Text cuhint;
    public Button[] hints;
    public Sprite fullhint;
    public Sprite emptyhint;
    
     public InputField code; // for the compiler 
   // public Text displayText; 
     void Start()
    {

        if (Exer != null)
        {
            Exercise.text = Exer.Question;
            AddPlayer();
            Debug.Log(Exer.ExerciseId + " : " + Exer.Question);
        }
        else
            Debug.Log("Error");
    }

    public void AddPlayer()
    {
        
        StartCoroutine(Database.Instance.Compile(code.text, isSuccessful =>
    {
         Debug.Log("aaa");
        //ps = Database.players;
    })); 
     }

     void ShowAnsser()
    {
        
        
//
//     foreach(PlayerClass pc in Database.players.players)
//   {
//     displayText.text += pc.username + "\n";
//  }
// 
    }

    // Update is called once per frame
    void Update()
    {

    }


  /*  
        public Exercises EXE;
        public Text displayText;

        public string Difuclty ="low";//InputField
        public int CurrentStage=1; //InputField
        // int x = Convert.ToInt32(CurrentStage.text);

        // Use this for initialization
        void Start()
        {
            StartCoroutine(Database.Instance.GetExercises(isSuccessful =>
            {
                ShowExerisise();
                EXE = Database.exercise;
            }));
        }

          public void Exercise()
        { 
        StartCoroutine(Database.Instance.ShowExercise(new ExerciseClass(Difuclty, CurrentStage), isSuccessful =>
                 {
                       ShowExerisise();
                       EXE= Database.exercise;
                     //
                 })); 
       }

        void ShowExerisise()
        {


                     displayText.text = "";

                     foreach (ExerciseClass EXE in Database.exercise.exercises)
                     {
                         displayText.text += EXE.Question + "\n";
                     }
                 }*/


    void ShowPlayerExercise(PlayerClass currentPlayer, MatchClass currentMatch, ExerciseClass currentExercise)
    {
        string Answer = "";
        if (gameObject.name == "UseHint")  //If (player clicked on “Use Hint” button)
        {
            for (int i = 0; i < hints.Length; i++)
            {
                if (i < hint)
                {
                    hints[i].image.sprite = fullhint;
                    Debug.Log("fullhint");
                }
                else
                {
                    hint--;
                    hints[i].image.sprite = emptyhint;
                    UseHints(currentMatch, currentExercise); //Call UseHints(currentMatch, currentExercise)
                }
            }
        }
        if (gameObject.name == "UseReRoll")//If (player clicked on “Use ReRoll” button)
        {
            AvailableRerolls(currentPlayer, currentMatch);  //   Call UseAvailableRerolls(currentPlayer, currentMatch)
        }

        RecordClass newRecord = SolveExercise(currentExercise,  currentMatch,  Answer);
        if (newRecord.HaveWon == "true")
        {
         //   Call ShowMatchBoard(currentMatchClass)
         // Call MoveToken(TokenType = player, steps)

        }else
        { 
            //	Call ShowMatchBoard(currentMatchClass) 


        }
    }

    private RecordClass SolveExercise(ExerciseClass exercise, MatchClass currentMatch, string answer)
    {
        throw new NotImplementedException();
    }

    private void AvailableRerolls(PlayerClass currentPlayer, MatchClass currentMatch)
    {


    }

    private HintClass UseHints(MatchClass currentMatch, ExerciseClass currentExercise)
    {
            if (currentMatch.availableHints <= 0)
            {
                  return null;// exit this function
            }
            else
            {
            currentMatch.availableHints--;//  decrease CurrentMatchClass.availableHints  by one
            int hintIndix =  rnd.Next(HintsExercice.Count);// currentExercise.hints[Random from 0 to max hints count]
            Displayhint = GameObject.Find("Hint");
            cuhint = Displayhint.GetComponent<Text>();
            cuhint.text = (string)HintsExercice[hintIndix];// Display the hint
            }
        return null;
        
    }
    
    

} 
    
