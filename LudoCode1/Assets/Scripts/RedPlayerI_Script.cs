using UnityEngine;
using System.Collections;

public class RedPlayerI_Script : MonoBehaviour {

	public static string redPlayerI_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			redPlayerI_ColName = col.gameObject.name;
			if (col.gameObject.name.Contains("Safe House")) {
				SoundManagerScript.safeHouseAudioSource.Play ();
			}
		}
	}

	void Start () 
	{
		redPlayerI_ColName = "none";
	}
}
