using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Dice : MonoBehaviour
{
    public static string server = "http://ludo-code.com";
    public static string path = "/";

    public Exercises EXE;
    protected int finalSide = 0;
    public Text UI;
    public string Difficulty = "low";//InputField
    public int CurrentStage = 1; //InputField
    //lods script of the PassNumSteps
    public PassNumSteps Script;
     string message;
     string Qusstion;
    public Text Q ;
    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;
    private int whosTurn = 1;
    private bool coroutineAllowed = true;
    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;
    private bool isSuccessful;

    // Start is called before the first frame update
    void Start()
    {
        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[3];

    }
    // If you left click over the dice then RollTheDice coroutine is started
    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed)
            StartCoroutine("RollTheDice");
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        coroutineAllowed = false;

        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;

        // Final side or value that dice reads in the end of coroutine
        

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 4);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;
        if (whosTurn == 1)
        {
            GameControl.MovePlayer(1);
        }
        else if (whosTurn == -1)
        {
            GameControl.MovePlayer(2);
        }
        whosTurn *= -1;
        coroutineAllowed = true;


        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;
   

         yield return new WaitForSeconds(0.06f);


       // UI.text = finalSide.ToString();
        Script.move = finalSide.ToString();
   
        
            SceneManager.LoadScene(4);
     

        //   }));


        // Show final dice value in Console
    //    Debug.Log(finalSide);
        //loades script of the finalSide

        

    }
    
}


