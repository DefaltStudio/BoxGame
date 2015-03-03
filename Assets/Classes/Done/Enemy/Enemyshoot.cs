using UnityEngine;
using System.Collections;

public class Enemyshoot : MonoBehaviour {

	Animator anim;

	public float activeRange = 10;
	
	static public Transform FPC;
	public Transform FPS;

	static public bool Open = false;


	void Start () 
		{
		FPC = FPS;
			anim = GetComponent<Animator> ();
		}

	void Update () 
	{
		float distanceToPlayer = Vector3.Distance(transform.position, FPC.position);
	

		if (distanceToPlayer <= activeRange) 
		{
			anim.SetBool("Open", true);

			Open = true;
		}

		if (distanceToPlayer >= activeRange) 
		{
			anim.SetBool ("Open", false);

			Open = false;
		}
	}
	
	void OnDrawGizmos()
	{
		Gizmos.color = Color.red;

		Gizmos.DrawWireSphere (transform.position, activeRange);
	}
}
