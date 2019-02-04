using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
        StartCoroutine(Database.Instance.GetPlayers(isSuccessful =>
        {
            SceneManager.LoadScene(1);
        }));

       
    }

     
}
