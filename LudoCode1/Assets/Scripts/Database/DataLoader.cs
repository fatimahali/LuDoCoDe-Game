using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataLoader : MonoBehaviour
{
    // RecordClass recordClass = Database.Instance.get_records();

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(Database.Instance.GetPlayers(isSuccessful =>
        {
            //RetrieveAllStages();
            SceneManager.LoadScene(1);
    }));
           
            

        


    }
    void RetrieveAllStages()
    {
        StartCoroutine(Database.Instance.get_records(isSuccessful =>
        {
            RetrieveAllPlayers();
          
        }));
    }
    void RetrieveAllPlayers() {
        StartCoroutine(Database.Instance.get_stages(isSuccessful =>
        {
         SceneManager.LoadScene(1);
        }));

    }


}
