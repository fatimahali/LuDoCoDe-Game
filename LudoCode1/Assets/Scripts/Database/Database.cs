using System;
using System.IO;
using UnityEngine;
using System.Xml.Serialization;
using System.Collections;

using System.Collections.Generic;

using System.Xml;
using System.Text;



public class Database : MonoBehaviour
{
   // UnityEngine.Random ran = new Random();

    public static string server = "http://ludo-code.com";
    public static string path = "/";

    private static Database instance = null;
    public static Database Instance
    {
        get
        {
            if (instance == null)
                instance = new GameObject("Database").AddComponent<Database>();

            return instance;
        }
    }

    public static Players players = new Players();
    public static Records records = new Records();
    public static Hints hints = new Hints();
    public static Exercises exercises = new Exercises();
    public static Stages stages = new Stages();


    public IEnumerator GetPlayers(System.Action<bool> callback)
    {
        bool isSuccessful = false;
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("id", 0);
        WWW www = new WWW(server + path + "get_players.php", wwwForm);

        yield return www;
        Debug.LogError(www.text.Trim());

        if (www.error == null)
        {
            isSuccessful = true;
            players = players.DeserializeObject(www.text.Trim());
        }
        else
            Debug.LogError(www.error);

        callback(isSuccessful);
    }
  
    public IEnumerator GetExercises(System.Action<bool> callback)
    {
        bool isSuccessful = false;
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("id", 0);
        WWW www = new WWW(server + path + "get_exercises.php", wwwForm);

        yield return www;
        Debug.LogError(www.text.Trim());


        if (www.error == null)
        {
            isSuccessful = true;
            exercises = exercises.DeserializeObject(www.text.Trim());
        }
        else
            Debug.LogError(www.error);

        callback(isSuccessful);
    }


    public IEnumerator UpdatePlayer(PlayerClass player, System.Action<bool> callback)
    {
        bool isSuccessful = false;
        WWWForm wwwForm = new WWWForm();

        wwwForm.AddField("id", player.Id);
        wwwForm.AddField("stage", player.CurrentStage);
        wwwForm.AddField("AvailableRerolls", player.AvailableRerolls);
        WWW www = new WWW(server + path + "get_exercise.php", wwwForm);
        yield return www;


        if (www.error == null)
        {
           players.UseAvailableRerolls(player.Id, player.CurrentStage, player.AvailableRerolls);
            if (!www.text.Contains("false"))
            {
                isSuccessful = true;
            }
        }
        else
            Debug.LogError(www.error);

        callback(isSuccessful);
       
    }
    /* public IEnumerator SetPlayerUI(PlayerClass player, System.Action<bool> callback)
     {
         bool isSuccessful = false;
         WWWForm wwwForm = new WWWForm();
         wwwForm.AddField("id", player.Id);
         WWW www = new WWW(server + path + "get_playerInfo.php", wwwForm);

         yield return www;
         Debug.LogError(www.text.Trim());

         if (www.error == null)
         {
             isSuccessful = true;
             players = players.DeserializeObject(www.text.Trim());
         }
         else
             Debug.LogError(www.error);

         callback(isSuccessful);
     }*/
    public IEnumerator get_stages(System.Action<bool> callback) 
    {
        bool isSuccessful = false;
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("id", 0);
        WWW www = new WWW(server + path + "get_stages.php", wwwForm);

        yield return www;
        Debug.LogError(www.text.Trim());

        if (www.error == null)
        {
            isSuccessful = true;
            stages = stages.DeserializeObject(www.text.Trim());
        }
        else
            Debug.LogError(www.error);

       callback(isSuccessful);
    }

    public IEnumerator get_records(System.Action<bool> callback)
    {
        bool isSuccessful = false;
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("Id", 0);
        WWW www = new WWW(server + path + "get_records.php", wwwForm);

        yield return www;
        Debug.LogError(www.text.Trim());

        if (www.error == null)
        {
            isSuccessful = true;
            records = records.DeserializeObject(www.text.Trim());
        }
        else
            Debug.LogError(www.error);

        callback(isSuccessful);
    }
    public IEnumerator get_hints(System.Action<bool> callback)
    {
        bool isSuccessful = false;
        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("id", 0);
        WWW www = new WWW(server + path + "get_hints.php", wwwForm);

        yield return www;
        Debug.LogError(www.text.Trim());

        if (www.error == null)
        {
            isSuccessful = true;
            hints = hints.DeserializeObject(www.text.Trim());
        }
        else
            Debug.LogError(www.error);

        callback(isSuccessful);
    }
   
    //public IEnumerator get_exercises(MatchClass currentMatch, int tokenPosition) // change 
    //{
        // Set ExerciseClass currentExercise =  random exercise depending on the current token
        //position and currentMatch . currentStage
      //  bool isSuccessful = false;
     //   WWWForm wwwForm = new WWWForm();
       // wwwForm.AddField("id", 0);
       // WWW www = new WWW(server + path + "get_exercises.php", wwwForm);

       // yield return www;
        //Debug.LogError(www.text.Trim());
       // string difficulty = "";
      //  if (www.error == null)
       // {
         //   isSuccessful = true;
           // exercise = exercise.DeserializeObject(www.text.Trim());

            //if (tokenPosition < 8)
            //{ difficulty = "Easy"; }
            //else if (tokenPosition < 16) { difficulty = "Medium"; }
            //else difficulty = "Hard";

            // List<ExerciseClass> matchedExercise;
          //  foreach(ExerciseClass exercise in currentMatch)
          //  {
            //    if (exercise.Difficulty == "Hard")
              //      matchedExercise.Add(exercise);

            //}

             

       // }
        //else
          //  Debug.LogError(www.error);

        //return matchedExercise[0bo];
        //callback(isSuccessful);


  

    /*
    public IEnumerator AddPlayer(PlayerClass player, System.Action<bool> callback)
    {
        bool isSuccessful = false;

        WWWForm wwwForm = new WWWForm();
        wwwForm.AddField("username", player.username);
        wwwForm.AddField("email", player.email);

        WWW www = new WWW(server + path + "Add_player.php", wwwForm);
        yield return www;


        if (www.error == null)
        {
            players.AddPlayer(player);
            if (!www.text.Contains("false"))
            {
                isSuccessful = true;
            }
        }
        else
            Debug.LogError(www.error);

        callback(isSuccessful);
    }
    */
  
}

[System.Serializable]
public class Players
{
    [SerializeField]
    public List<PlayerClass> players;

    public Players()
    {
        players = new List<PlayerClass>();
    }

    public void AddPlayer(PlayerClass player)
    {
        players.Add(player);
    }

    public void UpdatePlayer(PlayerClass player)
    {
        players.Add(player);
    }
    public PlayerClass GetPlayer(int id)
    {
        foreach (PlayerClass p in players)
        {
            if (p.Id == id)
             return p;
        }
      
        return null;
    }

    public PlayerClass UseAvailableRerolls( int id, int stage,int AvailableRerolls )
    {
        foreach (PlayerClass p in players)
        {
            if (p.Id == id)
                p.AvailableRerolls = AvailableRerolls;
                p.CurrentStage = stage;
            players.Add(p);

            return p;

        }

        return null;
    }
   

        #region Remote Save \ Load   
        public string SerializeObject()
    {
        string XmlizedString = null;
        MemoryStream memoryStream = new MemoryStream();

        XmlSerializer xs = new XmlSerializer(typeof(Players));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

        xs.Serialize(xmlTextWriter, this);

        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());

        return XmlizedString;
    }
    public Players DeserializeObject(string pXmlizedString)
    {
        XmlSerializer xs = new XmlSerializer(typeof(Players));
        MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        return xs.Deserialize(memoryStream) as Players;
    }

    string UTF8ByteArrayToString(byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }
    byte[] StringToUTF8ByteArray(string pXmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
    }
    #endregion 
}

/*
[System.Serializable]
public class PlayerClass
{
    public string username;
    public string email;

    public PlayerClass()
    {
        username = "";
        email = "";
    }

    public PlayerClass(string username, string email)
    {
        this.username = username;
        this.email = email;
    }
}
*/
[System.Serializable]
public class Records
{
    [SerializeField]
    public List<RecordClass> records;

    public Records()
    {
        records = new List<RecordClass>();
    }

    public void AddRecord(RecordClass record)
    {
        records.Add(record);
    }

    #region Remote Save \ Load   
    public string SerializeObject()
    {
        string XmlizedString = null;
        MemoryStream memoryStream = new MemoryStream();

        XmlSerializer xs = new XmlSerializer(typeof(Records));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

        xs.Serialize(xmlTextWriter, this);

        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());

        return XmlizedString;
    }

    public Records DeserializeObject(string pXmlizedString)
    {
        XmlSerializer xs = new XmlSerializer(typeof(Records));
        MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        return xs.Deserialize(memoryStream) as Records;
    }
    string UTF8ByteArrayToString(byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }
    byte[] StringToUTF8ByteArray(string pXmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
    }
    #endregion 
}

[System.Serializable]
public class RecordClass
{
    // need to update php file of this class

    public int PlayerId;
    public string HaveWon;
    public int TimeSpent;
    public int ExerciseId;
    public int Id;

    public RecordClass()
    {
        //Id = 0;
        ExerciseId = 0;
        PlayerId = 0;
        HaveWon = "";
        TimeSpent = 0;

    }

    public RecordClass(int PlayerId, string HaveWon, int TimeSpent, int ExerciseId, int Id)
    {
        this.Id = Id;
        this.ExerciseId = ExerciseId;
        this.PlayerId = PlayerId;
        this.HaveWon = HaveWon;
        this.TimeSpent = TimeSpent;
    }

}



[System.Serializable]
public class Exercises
{
    [SerializeField]
    public List<ExerciseClass> exercises;

    public Exercises()
    {
        exercises = new List<ExerciseClass>();
    }

    public void AddRecord(ExerciseClass exercise)
    {
        exercises.Add(exercise);
    }
    public ExerciseClass GetEexrcise(int id)
    {
        foreach (ExerciseClass p in exercises)
        {
            if (p.ExerciseId == id)
                return p;
        }

        return null;
    }


    #region Remote Save \ Load   
    public string SerializeObject()
    {
        string XmlizedString = null;
        MemoryStream memoryStream = new MemoryStream();

        XmlSerializer xs = new XmlSerializer(typeof(Exercises));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

        xs.Serialize(xmlTextWriter, this);

        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());
        return XmlizedString;
    }

    public Exercises DeserializeObject(string pXmlizedString)
    {
        XmlSerializer xs = new XmlSerializer(typeof(Exercises));
        MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        return xs.Deserialize(memoryStream) as Exercises;
    }
    string UTF8ByteArrayToString(byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }
    byte[] StringToUTF8ByteArray(string pXmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
    }
    #endregion 
}

[System.Serializable]
public class ExerciseClass
{
    public int ExerciseId;
    public string Question;
    public string Solution;
    public string ExerciseType;
    public string Difficulty;
    public int CurrentStage; //StageId

    public ExerciseClass()
    {
        //ExerciseId = ;
        Question = "";
        Solution = "";
        ExerciseType = "";
        Difficulty = "";
        CurrentStage = 0;
    }



    public ExerciseClass(int ExerciseId, string Question, string Solution, string ExerciseType, string Difficulty, int CurrentStage)
    {
        this.ExerciseId = ExerciseId;
        this.Question = Question;
        this.Solution = Solution;
        this.ExerciseType = ExerciseType;
        this.Difficulty = Difficulty;
        this.CurrentStage = CurrentStage;
    }

}



public class MatchClass
{
    public string currentStage;
    public int availableHints;
    public int playerTokenPosition;
    public int ComputerTokenPosition;
    public string currentTurn;


   public MatchClass()
    {
        currentStage = "";
        availableHints = 0;
        currentTurn = "";
        playerTokenPosition = 0 ;
        ComputerTokenPosition = 0 ;

    }
    public MatchClass(string currentStage, int availableHints,int playerTokenPosition, int ComputerTokenPosition)
    {
        this.currentStage = currentStage;
        this.availableHints = availableHints;
        this.ComputerTokenPosition = ComputerTokenPosition ;
        this.playerTokenPosition = playerTokenPosition ;
    }

}

[System.Serializable]
public class PlayerClass
{
    public int Id;
    public string Name;
    public string Email;
    public string Country;
    public int ExperiencePoints;
    public int TotalWonMatch;
    public int TotalPlayedMatch;
    public int AvailableRerolls;
    public int CurrentStage;

    public PlayerClass()
    {
      //  Id =0 ;
        Name = "";
        Email = "";
        Country = "";
        ExperiencePoints = 0;
        TotalWonMatch = 0;
        TotalPlayedMatch = 0;
        AvailableRerolls = 0;
        CurrentStage = 0;
    }

    public PlayerClass(int Id, string Name, string Email, string Country, int ExperiencePoints, int TotalWonMatch, int TotalPlayedMatch, int AvailableRerolls, int CurrentStage)
    {
        this.Id = Id;
        this.Name = Name;
        this.Email = Email;
        this.Country = Country;
        this.ExperiencePoints = ExperiencePoints;
        this.TotalWonMatch = TotalWonMatch;
        this.TotalPlayedMatch = TotalPlayedMatch;
        this.AvailableRerolls = AvailableRerolls;
        this.CurrentStage = CurrentStage;
    }
}

[System.Serializable]
public class Hints
{
    [SerializeField]
    public List<HintClass> hints;
    public  List<string> Currenthint;
    public Hints()
    {
        hints = new List<HintClass>();
    }
    public List<string> GetHints(int id)// id of currentExercise
    {
        foreach (HintClass h in hints)
        {
            if (h.ExerciseId == id)
                Currenthint.Add(h.Content);

                return Currenthint;
        }

        return null;
    }
   

    #region Remote Save \ Load   
    public string SerializeObject()
    {
        string XmlizedString = null;
        MemoryStream memoryStream = new MemoryStream();

        XmlSerializer xs = new XmlSerializer(typeof(Hints));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

        xs.Serialize(xmlTextWriter, this);

        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());

        return XmlizedString;
    }
    public Hints DeserializeObject(string pXmlizedString)
    {
        XmlSerializer xs = new XmlSerializer(typeof(Hints));
        MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        return xs.Deserialize(memoryStream) as Hints;
    }

    string UTF8ByteArrayToString(byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }
    byte[] StringToUTF8ByteArray(string pXmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
    }
    #endregion 
}

[System.Serializable]
public class HintClass
{
    public int id;
    public string Content;
    public int ExerciseId;


    public HintClass()
    {
        //id = ;
        Content = "";
        ExerciseId = 0;
    }

    public HintClass(int id, string Content, int ExerciseId)
    {
        this.id = id;
        this.Content = Content;
        this.ExerciseId = ExerciseId;
    }
}

[System.Serializable]
public class Stages
{
    [SerializeField]
    public List<PlayerClass> stages;

    public Stages()
    {
        stages = new List<PlayerClass>();  // Stagesclass
    }


    #region Remote Save \ Load   
    public string SerializeObject()
    {
        string XmlizedString = null;
        MemoryStream memoryStream = new MemoryStream();

        XmlSerializer xs = new XmlSerializer(typeof(Stages));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);

        xs.Serialize(xmlTextWriter, this);

        memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
        XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray());

        return XmlizedString;
    }
    public Stages DeserializeObject(string pXmlizedString)
    {
        XmlSerializer xs = new XmlSerializer(typeof(Stages));
        MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(pXmlizedString));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
        return xs.Deserialize(memoryStream) as Stages;
    }

    string UTF8ByteArrayToString(byte[] characters)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        string constructedString = encoding.GetString(characters);
        return (constructedString);
    }
    byte[] StringToUTF8ByteArray(string pXmlString)
    {
        UTF8Encoding encoding = new UTF8Encoding();
        byte[] byteArray = encoding.GetBytes(pXmlString);
        return byteArray;
    }
    #endregion 
}

[System.Serializable]
public class StageClass : MonoBehaviour
{
    public int StageNum;
    public string StageTitle;

    public StageClass()
    {
        StageNum = 0;
        StageTitle = "";
    }

    public StageClass(int StageNum, string StageTitle)
    {
        this.StageNum = StageNum;
        this.StageTitle = StageTitle;
    }
}

