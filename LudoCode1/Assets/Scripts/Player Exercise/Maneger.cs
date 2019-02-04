using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Maneger : MonoBehaviour
{

    public Text numSteps;

    public void goToScene(string sceneName)
    {       
        SceneManager.LoadScene(sceneName);

    }
}
