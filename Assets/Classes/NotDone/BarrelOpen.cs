using UnityEngine;
using System.Collections;

public class BarrelOpen : MonoBehaviour 
{
	public bool OpenBarrel = false;
	Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Enemyshoot.Open == true) 
		{
		
			anim.SetBool("OpenBarrel", true);
		}

		if (Enemyshoot.Open == false) 
		{
			
			anim.SetBool("OpenBarrel", false);
		}
	}
}
