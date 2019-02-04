using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class updateAvailableRerolls : MonoBehaviour
{
    PlayerClass myPlayer = Database.players.GetPlayer(1);
    public static string server = "http://ludo-code.com";
    public static string path = "/";

    public void AvailableRerolls(string stage)
    {

        int AvailableReroll = myPlayer.AvailableRerolls;


        if (AvailableReroll >= 0)
        {
            AvailableReroll--;// Decreasing currentPlayer.availableReRolls by one
            Debug.Log(AvailableReroll);
            //handleScore(int id, int stage, int AvailableRerolls)
            Rerolls(myPlayer.Id, myPlayer.CurrentStage, AvailableReroll);
            SceneManager.LoadScene("match" + stage);  // Call RollDice(currentMatch)

        }
    }

   IEnumerator Rerolls(int id, int stage, int AvailableRerolls)
    {


        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("Id", id);
        wwwForm.AddField("CurrentStage", stage);
        wwwForm.AddField("AvailableRerolls", AvailableRerolls);
        WWW www = new WWW(server + path + "get_exercise.php", wwwForm); //calls the php code  and access the data from the WAMP based database on my localhost
        yield return www;
        if (www.text == "Updated")
        {
            //  scoremgs = scoredata.text;
            Debug.Log("Updated");
        }
        else
        {
            Debug.Log("Loading");
            // scoremgs = "Loading!!!!!";

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
