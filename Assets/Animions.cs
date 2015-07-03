using UnityEngine;
using System.Collections;

public class Animions : MonoBehaviour 
{
	void Start () 
	{
		//anim = GetComponent<Animator> ();
        GetComponent<Animation>().Play();
	}
	
	void Update () 
	{

	}
}
