using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public PassNumSteps Script;
    public Exercises exercises;
    public GameObject GameObject;

    private int  totalRedInHouse, totalGreenInHouse;

    public GameObject frameRed, frameGreen;

    public GameObject redPlayerI_Border, redPlayerII_Border;
    public GameObject greenPlayerI_Border, greenPlayerII_Border;
    
    public Vector3 redPlayerI_Pos, redPlayerII_Pos;
    public Vector3 greenPlayerI_Pos, greenPlayerII_Pos;
  

    public Button RedPlayerI_Button, RedPlayerII_Button;
    public Button GreenPlayerI_Button, GreenPlayerII_Button;
   

    public GameObject  greenScreen, redScreen;
    public Text greenRankText, redRankText;

    private string playerTurn = "RED";
    public Transform diceRoll;
    public Button DiceRollButton;
    public Transform redDiceRollPos, greenDiceRollPos;

    private string currentPlayer = "none";
    private string currentPlayerName = "none";

    public GameObject redPlayerI, redPlayerII;
    public GameObject greenPlayerI, greenPlayerII;
    

    private int redPlayerI_Steps, redPlayerII_Steps;
    private int greenPlayerI_Steps, greenPlayerII_Steps;
   
    //selection of dice numbers animation...
    private int selectDiceNumAnimation;

    //--------------- Dice Animations------
    public GameObject dice1_Roll_Animation;
    public GameObject dice2_Roll_Animation;
    public GameObject dice3_Roll_Animation;
    public GameObject dice4_Roll_Animation;
   // public GameObject dice5_Roll_Animation;
  //  public GameObject dice4_Roll_Animation;

    // Players movement corenspoding to blocks...
    public List<GameObject> redMovementBlocks = new List<GameObject>();
    public List<GameObject> greenMovementBlocks = new List<GameObject>();
   

    // Random generation of dice numbers...
    private System.Random randomNo;
    public GameObject confirmScreen;
    public GameObject gameCompletedScreen;


    //to lude the currentMatchClass
    private void Awake()
    {
        // find Game object with Tage  returns single Game objcte with char the tag 
        // find Game objects with tag return  an array of such Game object 
        GameObject = GameObject.FindGameObjectsWithTag("GameObject")[0] as GameObject;
        MatchClass matchClass = Script.matchClass;
        // GetComponent loads the PassNumSteps
        Script = GameObject.GetComponent<PassNumSteps>();
        Debug.Log(matchClass.availableHints);
        //greenPlayerI_Steps = matchClass.playerTokenPosition;
        //greenPlayerII_Steps = matchClass.playerTokenPosition;
        //redPlayerI_Steps = matchClass.ComputerTokenPosition;
        // redPlayerII_Steps = matchClass.ComputerTokenPosition;
        //int vaerble = matchClass.availableHints;
        //string  stage = matchClass.currentStage;
        //playerTurn = matchClass.currentTurn;

    }
    //===== UI Button ===================
    public void quit()
    {
        SoundManagerScript.buttonAudioSource.Play();
        Application.Quit();
    }
    public void yesGameCompleted()
    {
        SoundManagerScript.buttonAudioSource.Play();
        SceneManager.LoadScene("match1");
    }

    public void noGameCompleted()
    {
        SoundManagerScript.buttonAudioSource.Play();
        SceneManager.LoadScene(2);
    }

    public void yesMethod()
    {
        SoundManagerScript.buttonAudioSource.Play();
        SceneManager.LoadScene(2);
    }

    public void noMethod()
    {
        SoundManagerScript.buttonAudioSource.Play();
        confirmScreen.SetActive(false);
    }

    public void ExitMethod()
    {
        SoundManagerScript.buttonAudioSource.Play();
        confirmScreen.SetActive(true);
    }
    // -============== GAME COMPLETED ROUTINE ==========================================================
    IEnumerator GameCompletedRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        gameCompletedScreen.SetActive(true);
    }

    // =================== ROLL DICE RESULT ============================================================

    // DICE Initialization after players have finished their turn---------------
    void InitializeDice()
    {
        DiceRollButton.interactable = true;

        dice1_Roll_Animation.SetActive(false);
        dice2_Roll_Animation.SetActive(false);
        dice3_Roll_Animation.SetActive(false);
        dice4_Roll_Animation.SetActive(false);

        //================= CHECKING PLAYERS WHO WINS SURING GAMEPLAY===================================

        switch (MainMenuScript.howManyPlayers)
        {
            case 2:
                if (totalRedInHouse > 1)
                {
                    SoundManagerScript.winAudioSource.Play();
                    redScreen.SetActive(true);
                    StartCoroutine("GameCompletedRoutine");
                    playerTurn = "NONE";
                }

                if (totalGreenInHouse > 1)
                {
                    SoundManagerScript.winAudioSource.Play();
                    greenScreen.SetActive(true);
                    StartCoroutine("GameCompletedRoutine");
                    playerTurn = "NONE";
                }
                break;
        }

        //======== Getting currentPlayer VALUE=======
        if (currentPlayerName.Contains("RED PLAYER"))
        {
            if (currentPlayerName == "RED PLAYER I")
                currentPlayer = RedPlayerI_Script.redPlayerI_ColName;
            if (currentPlayerName == "RED PLAYER II")
                currentPlayer = RedPlayerII_Script.redPlayerII_ColName;
           
        }

        if (currentPlayerName.Contains("GREEN PLAYER"))
        {
            if (currentPlayerName == "GREEN PLAYER I")
                currentPlayer = GreenPlayerI_Script.greenPlayerI_ColName;
            if (currentPlayerName == "GREEN PLAYER II")
                currentPlayer = GreenPlayerII_Script.greenPlayerII_ColName;
        }

      

        //================== Player vs Opponent=========================================================
        if (currentPlayerName != "none")
        {
            switch (MainMenuScript.howManyPlayers)
            {
                case 2:
                    if (currentPlayerName.Contains("RED PLAYER"))
                    {
                        if (currentPlayer == GreenPlayerI_Script.greenPlayerI_ColName && (currentPlayer != "Star" && GreenPlayerI_Script.greenPlayerI_ColName != "Star"))
                        {
                            SoundManagerScript.dismissalAudioSource.Play();
                            greenPlayerI.transform.position = greenPlayerI_Pos;
                            GreenPlayerI_Script.greenPlayerI_ColName = "none";
                            greenPlayerI_Steps = 0;
                            playerTurn = "RED";

                            
                        }
                        if (currentPlayer == GreenPlayerII_Script.greenPlayerII_ColName && (currentPlayer != "Star" && GreenPlayerII_Script.greenPlayerII_ColName != "Star"))
                        {
                            SoundManagerScript.dismissalAudioSource.Play();
                            greenPlayerII.transform.position = greenPlayerII_Pos;
                            GreenPlayerII_Script.greenPlayerII_ColName = "none";
                            greenPlayerII_Steps = 0;
                            playerTurn = "RED";
                        }
                      
                    }
                    if (currentPlayerName.Contains("GREEN PLAYER"))
                    {
                        if (currentPlayer == RedPlayerI_Script.redPlayerI_ColName && (currentPlayer != "Star" && RedPlayerI_Script.redPlayerI_ColName != "Star"))
                        {
                            SoundManagerScript.dismissalAudioSource.Play();
                            redPlayerI.transform.position = redPlayerI_Pos;
                            RedPlayerI_Script.redPlayerI_ColName = "none";
                            redPlayerI_Steps = 0;
                            playerTurn = "GREEN";
                        }
                        if (currentPlayer == RedPlayerII_Script.redPlayerII_ColName && (currentPlayer != "Star" && RedPlayerII_Script.redPlayerII_ColName != "Star"))
                        {
                            SoundManagerScript.dismissalAudioSource.Play();
                            redPlayerII.transform.position = redPlayerII_Pos;
                            RedPlayerII_Script.redPlayerII_ColName = "none";
                            redPlayerII_Steps = 0;
                            playerTurn = "GREEN";
                        }
                       
                    }
                    break;

            }
        }//===================================================================================

        switch (MainMenuScript.howManyPlayers)
        {
            case 2:
                if (playerTurn == "RED")
                {
                    diceRoll.position = redDiceRollPos.position;
                    Debug.Log("RED");
                    frameRed.SetActive(true);
                    frameGreen.SetActive(false);
                   
                }
                if (playerTurn == "GREEN")
                {
                    diceRoll.position = greenDiceRollPos.position;
                    Debug.Log("Green");
                    frameRed.SetActive(false);
                    frameGreen.SetActive(true);
                 
                }

                GreenPlayerI_Button.interactable = false;
                GreenPlayerII_Button.interactable = false;
              

                RedPlayerI_Button.interactable = false;
                RedPlayerII_Button.interactable = false;
              
                //=============ANIMATED ROUND BORDER=======
                redPlayerI_Border.SetActive(false);
                redPlayerII_Border.SetActive(false);
               

                greenPlayerI_Border.SetActive(false);
                greenPlayerII_Border.SetActive(false);
             
                //======================================
                break;

      
        }

        selectDiceNumAnimation = 0;
    }

    // Click on Roll Button on Dice UI
    public void DiceRoll()
    {
        SoundManagerScript.diceAudioSource.Play();
        DiceRollButton.interactable = false;

        selectDiceNumAnimation = randomNo.Next(1, 5);

        switch (selectDiceNumAnimation)
        {
            case 1:
                dice1_Roll_Animation.SetActive(true);
                dice2_Roll_Animation.SetActive(false);
                dice3_Roll_Animation.SetActive(false);
                dice4_Roll_Animation.SetActive(false);
            
                break;

            case 2:
                dice1_Roll_Animation.SetActive(false);
                dice2_Roll_Animation.SetActive(true);
                dice3_Roll_Animation.SetActive(false);
                dice4_Roll_Animation.SetActive(false);
            
                break;

            case 3:
                dice1_Roll_Animation.SetActive(false);
                dice2_Roll_Animation.SetActive(false);
                dice3_Roll_Animation.SetActive(true);
                dice4_Roll_Animation.SetActive(false);
              
                break;

            case 4:
                dice1_Roll_Animation.SetActive(false);
                dice2_Roll_Animation.SetActive(false);
                dice3_Roll_Animation.SetActive(false);
                dice4_Roll_Animation.SetActive(true);
                break;

        }
      
        StartCoroutine("PlayersNotInitialized");
    }

    IEnumerator PlayersNotInitialized()
    {
        yield return new WaitForSeconds(0.8f);
        // Game Start Initial position of each player (Red, Green, Blue, Yellow)
        switch (playerTurn)
        {
            case "RED":
                
                //==================== CONDITION FOR BORDER GLOW ========================
                if ((redMovementBlocks.Count - redPlayerI_Steps) >= selectDiceNumAnimation && redPlayerI_Steps > 0 && (redMovementBlocks.Count > redPlayerI_Steps))
                {
                    redPlayerI_Border.SetActive(true);
                    RedPlayerI_Button.interactable = true;

                   // yield return new WaitForSeconds(1.5f);
                    Debug.Log("redPlayerI_Steps " + selectDiceNumAnimation);
                }
                else
                {
                    redPlayerI_Border.SetActive(false);
                    RedPlayerI_Button.interactable = false;
                }

                if ((redMovementBlocks.Count - redPlayerII_Steps) >= selectDiceNumAnimation && redPlayerII_Steps > 0 && (redMovementBlocks.Count > redPlayerII_Steps))
                {
                    redPlayerII_Border.SetActive(true);
                    RedPlayerII_Button.interactable = true;
                    Debug.Log("redPlayerII_Steps" + selectDiceNumAnimation);
                }
                else
                {
                    redPlayerII_Border.SetActive(false);
                    RedPlayerII_Button.interactable = false;
                }

               
                //========================= PLAYERS BORDER GLOW WHEN OPENING ===========================================

                if (selectDiceNumAnimation == 4 && redPlayerI_Steps == 0)
                {
                    redPlayerI_Border.SetActive(true);
                    RedPlayerI_Button.interactable = true;
                }
                if (selectDiceNumAnimation == 4 && redPlayerII_Steps == 0)
                {
                    redPlayerII_Border.SetActive(true);
                    RedPlayerII_Button.interactable = true;
                }
              
                //====================== PLAYERS DON'T HAVE ANY MOVES ,SWITCH TO NEXT TURN===============================
                if (!redPlayerI_Border.activeInHierarchy && !redPlayerII_Border.activeInHierarchy )
                {
                    RedPlayerI_Button.interactable = false;
                    RedPlayerII_Button.interactable = false;
                  
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            InitializeDice();
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            InitializeDice();
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            InitializeDice();
                            break;
                    }
                }
                break;

           
            case "GREEN":
                
                //==================== CONDITION FOR BORDER GLOW ========================
                if ((greenMovementBlocks.Count - greenPlayerI_Steps) >= selectDiceNumAnimation && greenPlayerI_Steps > 0 && (greenMovementBlocks.Count > greenPlayerI_Steps))
                {
                    greenPlayerI_Border.SetActive(true);
                    GreenPlayerI_Button.interactable = true;
                    Script.move = selectDiceNumAnimation.ToString();
                    StartCoroutine(Database.Instance.GetExercises(isSuccessful =>
                    {
                        Debug.Log("Get Ewxerise");
                        SceneManager.LoadScene("Player Exercise");
                    }));
                   
                    Debug.Log("greenPlayerI_Steps " + selectDiceNumAnimation);
                }
                else
                {
                    greenPlayerI_Border.SetActive(false);
                    GreenPlayerI_Button.interactable = false;
                }

                if ((greenMovementBlocks.Count - greenPlayerII_Steps) >= selectDiceNumAnimation && greenPlayerII_Steps > 0 && (greenMovementBlocks.Count > greenPlayerII_Steps))
                {
                    greenPlayerII_Border.SetActive(true);
                    GreenPlayerII_Button.interactable = true;
                    Script.move = selectDiceNumAnimation.ToString();
                    StartCoroutine(Database.Instance.GetExercises(isSuccessful =>
                    {
                        Debug.Log("Get Ewxerise");
                        SceneManager.LoadScene("Player Exercise");
                    }));
                    Debug.Log("greenPlayerI_Steps "+ greenPlayerI_Steps +":"+ selectDiceNumAnimation);
                }
                else
                {
                    greenPlayerII_Border.SetActive(false);
                    GreenPlayerII_Button.interactable = false;
                }

              
                //=======================================================================================================

                if (selectDiceNumAnimation == 4 && greenPlayerI_Steps == 0)
                {
                    greenPlayerI_Border.SetActive(true);
                    GreenPlayerI_Button.interactable = true;
                }
                if (selectDiceNumAnimation == 4 && greenPlayerII_Steps == 0)
                {
                    greenPlayerII_Border.SetActive(true);
                    GreenPlayerII_Button.interactable = true;
                }
              
                //====================== PLAYERS DON'T HAVE ANY MOVES ,SWITCH TO NEXT TURN===============================
                if (!greenPlayerI_Border.activeInHierarchy && !greenPlayerII_Border.activeInHierarchy )
                {
                    GreenPlayerI_Button.interactable = false;
                    GreenPlayerII_Button.interactable = false;
                   

                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            InitializeDice();
                            break;

                        case 3:
                            //GREEN PLAYER IS NOT AVAILABLE
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            InitializeDice();
                            break;
                    }
                }
                break;

                case "YELLOW":

              break;
        }
    }

    //=============================== RED PLAYERS MOVEMENT ===========================================================

    public void redPlayerI_UI()
    {
        SoundManagerScript.playerAudioSource.Play();
        redPlayerI_Border.SetActive(false);
        redPlayerII_Border.SetActive(false);
      
        RedPlayerI_Button.interactable = false;
        RedPlayerII_Button.interactable = false;
       

        if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerI_Steps) > selectDiceNumAnimation) // 4 > 4
        {
            if (redPlayerI_Steps > 0)
            {
                Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer_Path[i] = redMovementBlocks[redPlayerI_Steps + i].transform.position;
                }

                redPlayerI_Steps += selectDiceNumAnimation;
                Debug.Log(redPlayerI_Steps);

                if (selectDiceNumAnimation == 4)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                //currentPlayer = RedPlayerI_Script.redPlayerI_ColName;
                currentPlayerName = "RED PLAYER I";

                //if(redPlayerI_Steps + selectDiceNumAnimation == redMovementBlocks.Count)
                if (redPlayer_Path.Length > 1)
                {
                    //redPlayerI.transform.DOPath (redPlayer_Path, 2.0f, PathType.Linear, PathMode.Full3D, 10, Color.red);
                    iTween.MoveTo(redPlayerI, iTween.Hash("path", redPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayerI, iTween.Hash("position", redPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
            else
            {
                if (selectDiceNumAnimation == 4 && redPlayerI_Steps == 0)
                {
                    Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];
                    redPlayer_Path[0] = redMovementBlocks[redPlayerI_Steps].transform.position;
                    redPlayerI_Steps += 1;
                    playerTurn = "RED";
                    //currentPlayer = RedPlayerI_Script.redPlayerI_ColName;
                    currentPlayerName = "RED PLAYER I";
                    iTween.MoveTo(redPlayerI, iTween.Hash("position", redPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of required moves to get into the House)
            if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerI_Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer_Path[i] = redMovementBlocks[redPlayerI_Steps + i].transform.position;
                }

                redPlayerI_Steps += selectDiceNumAnimation;

                playerTurn = "RED";

                //redPlayerI_Steps = 0;

                if (redPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(redPlayerI, iTween.Hash("path", redPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayerI, iTween.Hash("position", redPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                totalRedInHouse += 1;
                Debug.Log("Cool !!");
                RedPlayerI_Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (redMovementBlocks.Count - redPlayerI_Steps).ToString() + " to enter into the house.");

                if (redPlayerII_Steps == 0 && selectDiceNumAnimation != 4)
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                    InitializeDice();
                }
            }
        }
    }

    public void redPlayerII_UI()
    {
        SoundManagerScript.playerAudioSource.Play();
        redPlayerI_Border.SetActive(false);
        redPlayerII_Border.SetActive(false);
      
        RedPlayerI_Button.interactable = false;
        RedPlayerII_Button.interactable = false;
      

        if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerII_Steps) > selectDiceNumAnimation) // 4 > 4
        {
            if (redPlayerII_Steps > 0)
            {
                Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer_Path[i] = redMovementBlocks[redPlayerII_Steps + i].transform.position;
                }

                redPlayerII_Steps += selectDiceNumAnimation;


                Debug.Log(redPlayerII_Steps);
                if (selectDiceNumAnimation == 4)
                {
                    playerTurn = "RED";
                }
                else
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                }

                //currentPlayer = RedPlayerII_Script.redPlayerII_ColName;
                currentPlayerName = "RED PLAYER II";

                //if(redPlayerII_Steps + selectDiceNumAnimation == redMovementBlocks.Count)
                if (redPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("path", redPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("position", redPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
            else
            {
                if (selectDiceNumAnimation == 4 && redPlayerII_Steps == 0)
                {
                    Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];
                    redPlayer_Path[0] = redMovementBlocks[redPlayerII_Steps].transform.position;
                    redPlayerII_Steps += 1;
                    playerTurn = "RED";
                    //currentPlayer = RedPlayerII_Script.redPlayerII_ColName;
                    currentPlayerName = "RED PLAYER II";
                    iTween.MoveTo(redPlayerII, iTween.Hash("position", redPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of required moves to get into the House)
            if (playerTurn == "RED" && (redMovementBlocks.Count - redPlayerII_Steps) == selectDiceNumAnimation)
            {
                Vector3[] redPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    redPlayer_Path[i] = redMovementBlocks[redPlayerII_Steps + i].transform.position;
                }

                redPlayerII_Steps += selectDiceNumAnimation;

                playerTurn = "RED";

                //redPlayerII_Steps = 0;

                if (redPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("path", redPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(redPlayerII, iTween.Hash("position", redPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                totalRedInHouse += 1;
                Debug.Log("Cool !!");
                RedPlayerII_Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (redMovementBlocks.Count - redPlayerII_Steps).ToString() + " to enter into the house.");

                if (redPlayerI_Steps  == 0 && selectDiceNumAnimation != 4)
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "GREEN";
                            break;

                        case 3:
                            playerTurn = "BLUE";
                            break;

                        case 4:
                            playerTurn = "BLUE";
                            break;
                    }
                    InitializeDice();
                }
            }
        }
    }

   
    
    //==================================== GREEN PLAYERS MOVEMENT =================================================================

    public void greenPlayerI_UI()
    {
        SoundManagerScript.playerAudioSource.Play();
        greenPlayerI_Border.SetActive(false);
        greenPlayerII_Border.SetActive(false);
     
        GreenPlayerI_Button.interactable = false;
        GreenPlayerII_Button.interactable = false;
       

        if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerI_Steps) > selectDiceNumAnimation)
        {
            if (greenPlayerI_Steps > 0)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[greenPlayerI_Steps + i].transform.position;
                }

                greenPlayerI_Steps += selectDiceNumAnimation;
                Debug.Log("greenPlayerI_Steps"+ greenPlayerI_Steps);
                if (selectDiceNumAnimation == 4)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                currentPlayerName = "GREEN PLAYER I";

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayerI, iTween.Hash("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayerI, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
            }
            else
            {
                if (selectDiceNumAnimation == 4 && greenPlayerI_Steps == 0)
                {
                    Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
                    greenPlayer_Path[0] = greenMovementBlocks[greenPlayerI_Steps].transform.position;
                    greenPlayerI_Steps += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN PLAYER I";
                    iTween.MoveTo(greenPlayerI, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of requigreen moves to get into the House)
            if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerI_Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[greenPlayerI_Steps + i].transform.position;
                }

                greenPlayerI_Steps += selectDiceNumAnimation;

                playerTurn = "GREEN";

                //greenPlayerI_Steps = 0;

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayerI, iTween.Hash("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayerI, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                totalGreenInHouse += 1;
                Debug.Log("Cool !!");
                GreenPlayerI_Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (greenMovementBlocks.Count - greenPlayerI_Steps).ToString() + " to enter into the house.");

                if (greenPlayerII_Steps == 0 && selectDiceNumAnimation != 4)
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //Player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                    InitializeDice();
                }
            }
        }
    }

    public void greenPlayerII_UI()
    {
        SoundManagerScript.playerAudioSource.Play();
        greenPlayerI_Border.SetActive(false);
        greenPlayerII_Border.SetActive(false);
      
        GreenPlayerI_Button.interactable = false;
        GreenPlayerII_Button.interactable = false;
      

        if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerII_Steps) > selectDiceNumAnimation)
        {
            if (greenPlayerII_Steps > 0)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[greenPlayerII_Steps + i].transform.position;
                }

                greenPlayerII_Steps += selectDiceNumAnimation;
                Debug.Log("greenPlayerII_Steps"+ greenPlayerII_Steps);
                if (selectDiceNumAnimation == 4)
                {
                    playerTurn = "GREEN";
                }
                else
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                }

                currentPlayerName = "GREEN PLAYER II";

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayerII, iTween.Hash("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayerII, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));

                }
            }
            else
            {
                if (selectDiceNumAnimation == 4 && greenPlayerII_Steps == 0)
                {
                    Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];
                    greenPlayer_Path[0] = greenMovementBlocks[greenPlayerII_Steps].transform.position;
                    greenPlayerII_Steps += 1;
                    playerTurn = "GREEN";
                    currentPlayerName = "GREEN PLAYER II";
                    iTween.MoveTo(greenPlayerII, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
            }
        }
        else
        {
            // Condition when Player Coin is reached successfully in House....(Actual Number of requigreen moves to get into the House)
            if (playerTurn == "GREEN" && (greenMovementBlocks.Count - greenPlayerII_Steps) == selectDiceNumAnimation)
            {
                Vector3[] greenPlayer_Path = new Vector3[selectDiceNumAnimation];

                for (int i = 0; i < selectDiceNumAnimation; i++)
                {
                    greenPlayer_Path[i] = greenMovementBlocks[greenPlayerII_Steps + i].transform.position;
                }

                greenPlayerII_Steps += selectDiceNumAnimation;

                playerTurn = "GREEN";

                //greenPlayerII_Steps = 0;

                if (greenPlayer_Path.Length > 1)
                {
                    iTween.MoveTo(greenPlayerII, iTween.Hash("path", greenPlayer_Path, "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }
                else
                {
                    iTween.MoveTo(greenPlayerII, iTween.Hash("position", greenPlayer_Path[0], "speed", 125, "time", 2.0f, "easetype", "elastic", "looptype", "none", "oncomplete", "InitializeDice", "oncompletetarget", this.gameObject));
                }

                totalGreenInHouse += 1;
                Debug.Log("Cool !!");
                GreenPlayerII_Button.enabled = false;
            }
            else
            {
                Debug.Log("You need " + (greenMovementBlocks.Count - greenPlayerII_Steps).ToString() + " to enter into the house.");

                if (greenPlayerI_Steps  == 0 && selectDiceNumAnimation != 4)
                {
                    switch (MainMenuScript.howManyPlayers)
                    {
                        case 2:
                            playerTurn = "RED";
                            break;

                        case 3:
                            //Player is not available
                            break;

                        case 4:
                            playerTurn = "YELLOW";
                            break;
                    }
                    InitializeDice();
                }
            }
        }
    }
    
    
    //=============================================================================================================================
    // Use this for initialization
    void Start()

    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;

        randomNo = new System.Random();

        dice1_Roll_Animation.SetActive(false);
        dice2_Roll_Animation.SetActive(false);
        dice3_Roll_Animation.SetActive(false);
        dice4_Roll_Animation.SetActive(false);
      //  dice5_Roll_Animation.SetActive(false);
      //  dice4_Roll_Animation.SetActive(false);

        // Players initial positions.....
        redPlayerI_Pos = redPlayerI.transform.position;
        redPlayerII_Pos = redPlayerII.transform.position;
       // redPlayerIII_Pos = redPlayerIII.transform.position;
       // redPlayerIV_Pos = redPlayerIV.transform.position;

        greenPlayerI_Pos = greenPlayerI.transform.position;
        greenPlayerII_Pos = greenPlayerII.transform.position;
      

       
        redPlayerI_Border.SetActive(false);
        redPlayerII_Border.SetActive(false);
       

      

        greenPlayerI_Border.SetActive(false);
        greenPlayerII_Border.SetActive(false);
        

        redScreen.SetActive(false);
        greenScreen.SetActive(false);
      

        // Initilaizing players here....
        switch (MainMenuScript.howManyPlayers)
        {
            case 2:
                playerTurn = "RED";

                frameRed.SetActive(true);
                frameGreen.SetActive(false);
              
                //diceRoll.position = redDiceRollPos.position;
              
                break;

          
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}