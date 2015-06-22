using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour 
{
	public Transform FPC;
	public float RotationSpeed;
	public float ActiveRange;

	private Vector3 direction;
	private Quaternion lookRotation;
	void Start () 
	{
	
	}

	void Update () 
	{

		//GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

	/*	//Find hvor langt FPC (First person Controller) er væk
		float DistanceToTarget = Vector3.Distance(FPC.position, transform.position);


		//Find vejen den skal vende
		direction = (FPC.position - transform.position).normalized;

		//Find hvilken rotation vi skal have.
		lookRotation = Quaternion.LookRotation (direction);

		//kig på target hvis den er inden for range
*/
		if (DistanceToTarget < ActiveRange) 
		{
			transform.LookAt (FPC);
			//transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);
		}
			//Shoot();

	
	}

	void Shoot ()
	{
		//Invoke(Shoot,2)
		//transform.LookAt(FPC);
	}
}
