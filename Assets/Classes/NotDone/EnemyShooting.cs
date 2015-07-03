using UnityEngine;
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



    private bool animHasPlayed = false;

	private float nextFire = 0.0f;

	private Vector3 direction;
	private Quaternion lookRotation;

	void Start () 
	{

	}

	void Update ()
	{
	
		Animation Test = GetComponentInParent<Animation> ();

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
				Test ["EnemyShootAnim"].speed = 1;
                GetComponentInParent<Animation>().Play();
                animHasPlayed = true;
            }
            
            if (!GetComponentInParent<Animation>().isPlaying)
                Shoot();
		}
	    
        if (DistanceToTarget > ActiveRange)
        {
            if (animHasPlayed)

				Test ["EnemyShootAnim"].speed = -1;

				GetComponentInParent<Animation>().Play();
                Debug.Log("Playing Backwards....");

            animHasPlayed = false;
        }
	}

	void Shoot ()
	{

		transform.rotation = Quaternion.Slerp (transform.rotation,lookRotation, Time.deltaTime * RotationSpeed);
		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (Bullet, Spawn.position, Spawn.rotation);

		}
	
	}
}
