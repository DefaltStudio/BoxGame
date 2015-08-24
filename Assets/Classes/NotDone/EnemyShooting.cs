using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour 
{
	public static Transform playerSpawn;
	public Transform bulletSpawn;
	public GameObject bullet;
	public float rotationSpeed;
	public float activeRange;

	public float fireRate = 0.5f;

	public Transform ball;

    private bool animHasPlayed = false;
	public bool hasPlayed = false;

	private float nextFire = 0.0f;

	private Vector3 targetDirection;
	private Quaternion lookRotation;


	void LateUpdate()
	{	
		Animation EnemyShotAnimationComp = GetComponentInParent<Animation> ();

		//Find hvor langt FPC (First person Controller) er væk
		float distanceToPlayer = Vector3.Distance(playerSpawn.position, transform.position);

		//Find vejen den skal vende
		targetDirection = (playerSpawn.position - transform.position).normalized;

		//Find hvilken rotation vi skal have.
		lookRotation = Quaternion.LookRotation (targetDirection);

		//kig på target hvis den er inden for range

        GetComponentInParent<Animation>().wrapMode = WrapMode.Once;
		if (distanceToPlayer < activeRange)
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
	    
        if (distanceToPlayer > activeRange)
        {
            if (animHasPlayed)
            {
                EnemyShotAnimationComp["EnemyShootAnim"].speed = -1;
                EnemyShotAnimationComp["EnemyShootAnim"].time = EnemyShotAnimationComp["EnemyShootAnim"].length;
                GetComponentInParent<Animation>().Play();
            }

            animHasPlayed = false;
        }

		if (hasPlayed == false) 
		{
			Instantiate (ball, new Vector3(transform.position.x, transform.position.y, transform.position.z - activeRange), Quaternion.identity);
			Instantiate (ball, new Vector3(transform.position.x, transform.position.y, transform.position.z + activeRange), Quaternion.identity);
			Instantiate (ball, new Vector3(transform.position.x + activeRange, transform.position.y, transform.position.z), Quaternion.identity);
			Instantiate (ball, new Vector3(transform.position.x - activeRange, transform.position.y, transform.position.z), Quaternion.identity);
			hasPlayed = true;
		}
	}


	void Shoot()
	{
		transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

		if (Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate (bullet, bulletSpawn.position, bulletSpawn.rotation);
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, activeRange); 
	}
}
