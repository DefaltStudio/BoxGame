using UnityEngine;
using System.Collections;

public class Animions : MonoBehaviour 
{

	public bool Working = false;

	void Start () 
	{
	
	}
	
	void Update () 
	{
		if (Working == true) 
		{
			GetComponent<Animation> ().Play ();
		}
	}

	public static void Animations()
	{
		Working = true;
	}
}
