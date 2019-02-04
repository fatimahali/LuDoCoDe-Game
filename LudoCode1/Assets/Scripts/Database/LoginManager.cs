using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    public Players ps = new Players();
    public Text displayText;

    public InputField username;
    public InputField email;


	// Use this for initialization
	void Start ()
    {
        StartCoroutine(Database.Instance.GetPlayers(isSuccessful =>
        {
            ShowPlayers();
            ps = Database.players;
        })); 
    }

 //   public void AddPlayer()
   // { 
       // StartCoroutine(Database.Instance.AddPlayer(new PlayerClass(username.text, email.text), isSuccessful =>
     //   {
       //     ShowPlayers();
         //   ps = Database.players;
        //})); 
    //}
	
	 void ShowPlayers()
    {
        displayText.text = "";

        foreach(PlayerClass pc in Database.players.players)
        {
           // displayText.text += pc.username + "\n";
        }
    }
}
