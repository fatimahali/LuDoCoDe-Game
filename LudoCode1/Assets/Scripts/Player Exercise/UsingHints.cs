using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UsingHints : MonoBehaviour
{
    public int hint;
    public int numofhints = 5;


    public Image[] hints;
    public Sprite fullhint;
    public Sprite emptyhint;
     void Update()
    { 
        for(int i=0; i < hints.Length; i++)
        {
            if(hint > numofhints)
            {
                hint = numofhints;
            }

            if (i < hint)
            {
                hints[i].sprite = fullhint;
            }
            else
            {
               // hint--;
                hints[i].sprite = emptyhint;
            }

            if (i < numofhints)
            {
                hints[i].enabled = true;
               

            }else
            {
                hints[i].enabled = false;
            }
        }

        
     
    }

}
