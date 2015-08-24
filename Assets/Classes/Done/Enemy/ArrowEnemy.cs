using UnityEngine;
using System.Collections;

public class ArrowEnemy : MonoBehaviour {

    [Range(3.0f, 8.0f)]
    public float activeRange = 4.0f;
    public float rotationSpeed = 1.5f;
    public float fireRate = 0.8f;
    public GameObject Bullet;
    public Transform bulletSpawn;

    public static Transform playerTransform;

    private float nextFire = 0.0f;
    private Vector3 targetDirection;
    private Quaternion lookRotation;
    private Quaternion startRotation;

    void Start()
    {
        startRotation = transform.rotation;
    }

	void LateUpdate()
    {
        float distanceToPlayer = Vector3.Distance(playerTransform.position, transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        if (distanceToPlayer < activeRange)
        {
            targetDirection = (playerTransform.position - transform.position).normalized;
            lookRotation = Quaternion.LookRotation(targetDirection);

            Shoot();
        }
        else // if not in range, reset rotation
        {
            lookRotation = startRotation;
        }
    }

    private void Shoot()
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(Bullet, bulletSpawn.position, transform.rotation);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, activeRange);
    }
}
