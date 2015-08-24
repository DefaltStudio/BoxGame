using UnityEngine;
using System.Collections;

public class BulletForce : MonoBehaviour {

    public GameObject explosion;

    void Awake()
    {
        //explosion = GameObject.FindWithTag("Explosion1");
    }

	IEnumerator Start() 
	{
		GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * 10000);
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
	}
	
	void OnCollisionEnter(Collision hit) 
    {
        if (hit.gameObject.tag != Tags.enemy)
        {
            if (explosion != null)
                Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
