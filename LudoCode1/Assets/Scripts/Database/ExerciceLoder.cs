using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ExerciceLoder : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Database.Instance.GetExercises(isSuccessful =>
        {
            Debug.Log("oooo");
        }));


    }
}