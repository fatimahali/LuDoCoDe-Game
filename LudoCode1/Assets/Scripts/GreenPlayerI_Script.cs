using UnityEngine;
using System.Collections;

public class GreenPlayerI_Script : MonoBehaviour {

	public static string greenPlayerI_ColName;

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "blocks") 
		{
			greenPlayerI_ColName = col.gameObject.name;
			if (col.gameObject.name.Contains("Safe House")) {
				SoundManagerScript.safeHouseAudioSource.Play ();
			}
		}
	}

	void Start () 
	{
		greenPlayerI_ColName = "none";
	}
}
