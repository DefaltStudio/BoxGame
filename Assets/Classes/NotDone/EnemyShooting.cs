using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour 
{

	void Start () 
	{
	
	}

	void Update () 
	{
		if (Enemyshoot.Open == true) 
		{
			Shoot();
		}
	}

	void Shoot ()
	{
		//Invoke(Shoot,2)
		transform.LookAt(Enemyshoot.FPC);
	}
}
