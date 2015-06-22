using UnityEngine;
using System.Collections;

public class GoldCube : MonoBehaviour 
{
	public GameObject GoldExplosion;
    void Start()
    {
        Manager.goldCubes.Add(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Gold cube collected!");
            Manager.goldCubes.Remove(gameObject);
			Instantiate(GoldExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
