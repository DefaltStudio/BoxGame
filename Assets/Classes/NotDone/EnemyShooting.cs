﻿using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour 
{
	public static Transform FPC;
	public Transform Spawn;
	public Transform Bullet;
	public float RotationSpeed;
	public float ActiveRange;

	public float Temprotation = 0.0f;
	public float fireRate = 0.5f;

	public Transform Ball;

    private bool animHasPlayed = false;
	public bool HasPlayed = false;

	private float nextFire = 0.0f;

	private Vector3 direction;
	private Quaternion lookRotation;


	void Update ()
	{	

		Animation EnemyShotAnimationComp = GetComponentInParent<Animation> ();

		//Find hvor langt FPC (First person Controller) er væk
		float DistanceToTarget = Vector3.Distance(FPC.position, transform.position);

		//Find vejen den skal vende
		direction = (FPC.position - transform.position).normalized;

		//Find hvilken rotation vi skal have.
		lookRotation = Quaternion.LookRotation (direction);

		//kig på target hvis den er inden for range

        GetComponentInParent<Animation>().wrapMode = WrapMode.Once;
		if (DistanceToTarget < ActiveRange)
        {
            if (!animHasPlayed)
            {
				EnemyShotAnimationComp["EnemyShootAnim"].speed = 1;
                GetComponentInParent<Animation>().Play();
                animHasPlayed = true;
            }
            
            if (!GetComponentInParent<Animation>().isPlaying)
                Shoot();
		}
	    
        if (DistanceToTarget > ActiveRange)
        {
            if (animHasPlayed)
            {
                EnemyShotAnimationComp["EnemyShootAnim"].speed = -1;
                EnemyShotAnimationComp["EnemyShootAnim"].time = EnemyShotAnimationComp["EnemyShootAnim"].length;
                GetComponentInParent<Animation>().Play();
            }

            animHasPlayed = false;
        }

		if (HasPlayed == false) 
		{
			Instantiate (Ball, new Vector3(transform.position.x, transform.position.y, transform.position.z - ActiveRange), Quaternion.identity);
			Instantiate (Ball, new Vector3(transform.position.x, transform.position.y, transform.position.z + ActiveRange), Quaternion.identity);
			Instantiate (Ball, new Vector3(transform.position.x + ActiveRange, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate (Ball, new Vector3(transform.position.x - ActiveRange, transform.position.y, transform.position.z), Quaternion.identity);
			HasPlayed = true;
		}

	}


	void Shoot ()
	{
		transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * RotationSpeed);

		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (Bullet, Spawn.position, Spawn.rotation);

		}
	
	}

	
	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		
		Gizmos.DrawWireSphere (transform.position, ActiveRange); 
		
	}
}
