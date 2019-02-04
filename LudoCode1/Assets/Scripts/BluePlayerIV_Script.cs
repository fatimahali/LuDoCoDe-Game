using UnityEngine;
using System.Collections;

public class BluePlayerIV_Script : MonoBehaviour {

	public static string bluePlayerIV_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			bluePlayerIV_ColName = col.gameObject.name;
			if (col.gameObject.name.Contains("Safe House")) {
				SoundManagerScript.safeHouseAudioSource.Play ();
			}
		}
	}

	void Start () 
	{
		bluePlayerIV_ColName = "none";
	}
}
