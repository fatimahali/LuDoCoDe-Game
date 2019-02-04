using UnityEngine;
using System.Collections;

public class YellowPlayerIV_Script : MonoBehaviour {

	public static string yellowPlayerIV_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			yellowPlayerIV_ColName = col.gameObject.name;
			if (col.gameObject.name.Contains("Safe House")) {
				SoundManagerScript.safeHouseAudioSource.Play ();
			}
		}
	}

	void Start () 
	{
		yellowPlayerIV_ColName = "none";
	}
}
