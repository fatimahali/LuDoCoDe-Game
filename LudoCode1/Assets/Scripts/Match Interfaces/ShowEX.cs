using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowEX : MonoBehaviour
{

    public static string server = "http://ludo-code.com";
    public static string path = "/";

    public Exercises EXE;
    public string Difficulty = "low";//InputField
    public int CurrentStage = 1; //InputField
    string message;
    string Qusstion;
    public Text Q;
    private bool isSuccessful;
    // Start is called before the first frame update
    void Start()
    {
        UserInfo();


    }

    // Update is called once per frame
    
    private IEnumerator UserInfo()
    {
        WWWForm logform = new WWWForm();
        logform.AddField("Difficulty", Difficulty);
        logform.AddField("CurrentStage", CurrentStage);

        WWW logw = new WWW(server + path + "EX.php", logform);
        yield return logw;


        Debug.LogError(logw.text.Trim());

        if (logw.error == null)
        {
            isSuccessful = true;
            message += logw.text.Trim();
            // exercise = exercise.DeserializeObject(logw.text.Trim());
        }
        else
            Debug.LogError(logw.error);
        if (message == "success! ")
        {
            Qusstion = message;
            Q.text = Qusstion.ToString();
        }
    }
}
