using UnityEngine;
using System.Collections;

public class RedPlayerIII_Script : MonoBehaviour {

	public static string redPlayerIII_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			redPlayerIII_ColName = col.gameObject.name;
			if (col.gameObject.name.Contains("Safe House")) {
				SoundManagerScript.safeHouseAudioSource.Play ();
			}
		}
	}

	void Start () 
	{
		redPlayerIII_ColName = "none";
	}
}