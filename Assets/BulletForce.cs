using UnityEngine;
using System.Collections;

public class BulletForce : MonoBehaviour {

    public GameObject explosion;

    void Awake()
    {
        //explosion = GameObject.FindWithTag("Explosion1");
    }

	void Start() 
	{
		GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10000);
	}
	
	void OnCollisionEnter(Collision hit) 
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
	}
}
