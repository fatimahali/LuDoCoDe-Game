using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameBounceControl : MonoBehaviour
{
    public InputField code;
    public static bool test = true;
    public static int Nameper = GameScript.selectDiceNumAnimation;
    public static int Reroll =GameScript.reRolle;
    public static int greenPlayerI_Step;
    public static int greenPlayerII_Step;
    public static int redPlayerI_Step;
    public static int redPlayerII_Step;
    public void Answer()
    {
        if (code.text.ToString() == "1")
        {
            test = true;
            runButton(test);
        }
        else
            runButton(test);
    }



    public void runButton(bool test)
    {
        if(test == true)
        {
            if (GameScript.redPlayerI_Steps > 0)
            {
                Nameper += GameScript.redPlayerI_Steps;
                Reroll++;
                Debug.Log("Reroll" + Reroll);
                greenPlayerI_Step = GameScript.greenPlayerI_Steps;
                greenPlayerII_Step = GameScript.greenPlayerII_Steps;
                Nameper = GameScript.redPlayerI_Steps;
                redPlayerII_Step = GameScript.redPlayerII_Steps;
                SceneManager.LoadScene("match1");
            }
            else if (GameScript.redPlayerII_Steps > 0)
            {
                Nameper += GameScript.redPlayerII_Steps;
                Reroll++;
                greenPlayerI_Step = GameScript.greenPlayerI_Steps;
                greenPlayerII_Step = GameScript.greenPlayerII_Steps;
                redPlayerI_Step = GameScript.redPlayerI_Steps;
                Nameper = GameScript.redPlayerII_Steps;
                SceneManager.LoadScene("match1");
            }
        }
        else
        {
            if (GameScript.redPlayerI_Steps > 0)
            {
                Nameper = GameScript.redPlayerI_Steps;
                greenPlayerI_Step = GameScript.greenPlayerI_Steps;
                greenPlayerII_Step = GameScript.greenPlayerII_Steps;
                redPlayerI_Step = GameScript.redPlayerI_Steps;
                redPlayerII_Step = GameScript.redPlayerII_Steps;
                SceneManager.LoadScene("match1");
            }
            else if (GameScript.redPlayerII_Steps > 0)
            {
                Nameper = GameScript.redPlayerII_Steps;
                greenPlayerI_Step = GameScript.greenPlayerI_Steps;
                greenPlayerII_Step = GameScript.greenPlayerII_Steps;
                redPlayerI_Step = GameScript.redPlayerI_Steps;
                redPlayerII_Step = GameScript.redPlayerII_Steps;
                SceneManager.LoadScene("match1");
            }
        }

    }
}
